create database bdPadariaTCC
use bdPadariaTCC
go

create table tbCliente (
codCliente int primary key identity (1,1)
,nomeCliente  varchar (50) 
,rgCliente varchar (14) 
,cpfCliente varchar (15) 
)

create table tbFuncionario(
codFuncionario int primary key identity (1,1)
,nomeFuncionario varchar(100) not null
,cpfFuncionario varchar(14) not null
,loginFuncionario varchar (100) not null
,senhaFuncionario varchar (255) not null
)
create table tbTelefoneFuncionario(
codTelefoneFuncionario int primary key identity (1,1)
,descricaoTelefoneFuncionario varchar(14)not null
,codFuncionario int foreign key references tbFuncionario (codFuncionario)
)

create table tbTelefoneCliente(
codTeleCliente int primary key identity (1,1)
,descricaoTeleCliente varchar(50)not null
,codCliente int foreign key references tbCliente (codCliente)
)

create table tbFormaPagamento(
codFormaPagamento int primary key identity (1,1)
,descricaoFormaPagamento varchar (50)not null
)
create table tbComanda(
codComanda int primary key identity (1,1)
,dataAbertura smalldatetime not null
)
create table tbVenda(
codVenda int primary key identity (1,1)
,valorTotalVenda smallmoney not null
,dataVenda smalldatetime not null
,horaVenda time not null
,codCliente int foreign key references tbCliente(codCliente)
,codComanda int foreign key references tbComanda (codComanda) 
)
create table tbParcelaPagamento(
codParcelaPagamento int primary key identity (1,1)
,numeroParcelaPagamento int not null
,valorParcelaPagamento smallmoney not null
,codFormaPagamento int foreign key references tbFormaPagamento (codFormaPagamento)
,codVenda int foreign key references tbVenda (codVenda)

)
create table tbEncomenda (
codEncomenda int primary key identity (1,1)
,descricaoEncomenda varchar (50) not null
,codCliente int foreign key references tbCliente (codCliente)
,valorTotalEncomenda smallmoney not null 
,dataEncomenda datetime not null
,horaEntregaEncomenda time not null
,dataEntregaEncomenda datetime not null
,codVenda int foreign key references tbVenda (codVenda)
)



create table tbTipoProduto(
codTipoProduto int primary key identity (1,1)
,descricao varchar (50) not null
)
create table tbFornecedor(
codFornecedor int primary key identity (1,1)
,nomeFornecedor varchar (50) not null
)

create table tbTelefoneFornecedor(
codTelefoneFornecedor int primary key identity(1,1)
,descricaoTelefoneFornecedor varchar (14) not null
,codFornecedor int foreign key references tbFornecedor(codFornecedor)
)

create table tbProduto(
codProduto int primary key identity (1,1)
,nomeProduto varchar (50) not null
,codTipoProduto int foreign key references tbTipoProduto (codTipoProduto)
,quantidadeProduto int not null
,valorUnitario smallmoney not null
,codFornecedor int foreign key references tbFornecedor (codFornecedor)
)
create table tbEncomendaProduto(
codEncomendaProduto int primary key identity (1,1)
,codProduto int foreign key references tbProduto (codProduto)
,codEncomenda int foreign key references tbEncomenda (codEncomenda)
,quantidadePoduto int not null
,subTotalEncomenda smallmoney not null
)


create table tbVendaProduto(
codVendaProduto int primary key identity (1,1)
,quantidadeProduto int not null
,valorTotal smallmoney not null
,subTotal smallmoney not null
,codVenda int foreign key references tbVenda (codVenda)
,codProduto int foreign key references tbProduto (codProduto)
)


create table tbMotivoEntradaCaixa(
codMotivoEntradaCaixa int primary key identity (1,1)
,descricaoMotivoEntradaCaixa varchar (50) not null

)
create table tbEntradaCaixa(
codEntradaCaixa int primary key identity (1,1)
,valorEntradaProduto smallmoney not null
,dataEntradaCaixa smalldatetime not null
,codMotivoEntrada int foreign key references tbMotivoEntradaCaixa (codMotivoEntradaCaixa)
)
create table tbMotivoSaidaCaixa(
codMotivoSaidaCaixa int primary key identity (1,1)
,descricaoMotivoSaidaCaixa varchar (50)not null
)
create table tbSaidaCaixa(
codSaidaCaixa int primary key identity (1,1)
,valorSaidaCaixa smallmoney not null
,dataSaidaCaixa smalldatetime not null
,codMotivoSaidaCaixa int foreign key references tbMotivoSaidaCaixa (codMotivoSaidaCaixa)
)


create table tbMotivoEntradaEstoque(
codMotivoEntradaEstoque int primary key identity (1,1)
,descricaoMotivoEntradaEstoque varchar (50) not null

)
create table tbEntradaEstoque(
codEntradaEstoque int primary key identity (1,1)
,valorEntradaProdutoEstoque smallmoney not null
,dataEntradaEstoque smalldatetime not null
,codMotivoEntradaEstoque int foreign key references tbMotivoEntradaEstoque (codMotivoEntradaEstoque)
,codProduto int foreign key references tbProduto (codProduto)
)
create table tbMotivoSaidaEstoque(
codMotivoSaidaEstoque int primary key identity (1,1)
,descricaoMotivoSaidaEstoque varchar (50)not null
)
create table tbSaidaEstoque(
codSaidaEstoque int primary key identity (1,1)
,valorSaidaEstoque smallmoney not null
,dataSaidaEstoque smalldatetime not null
,codMotivoSaidaEstoque int foreign key references tbMotivoSaidaEstoque (codMotivoSaidaEstoque)
,codProduto int foreign key references tbProduto (codProduto)
)

select * from tbFornecedor
delete from  tbFornecedor where codFornecedor = codFornecedor
select * from tbProduto
delete from  tbProduto where codProduto = codProduto

select * from tbFuncionario
select * from tbTelefoneFornecedor
SELECT nomeFornecedor,descricaoTelefoneFornecedor from tbFornecedor inner join tbTelefoneFornecedor on tbFornecedor.codFornecedor=tbTelefoneFornecedor.codFornecedor 