USE RPBDIS

SET NOCOUNT ON

DECLARE



@Position int,

@Symbol CHAR(52) = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz',

@Name nvarchar(50),

@Type nvarchar(50),

@Id int,
@CompanyId int,
@ProductionId int,

@feature nvarchar(50),

@TypeUnit nvarchar(50),

@i int,

@OPlan int,

@OFact int,

@RPlan int,

@RFact int,

@Quarter int,

@Year int,

@NameLimit int,

@RowCount int,

@NumberCompanies int,

@NumberProductionTypes int,

@NumberProductions int,

@NumberOutputs int,

@NumberReleases int,

@MinNumberSymbols int,

@MaxNumberSymbols int,

@Name1 nvarchar(50),

@Number int

SET @NumberCompanies = 100

SET @NumberProductionTypes = 250

SET @NumberProductions = 250

SET @NumberOutputs = 1000

SET @NumberReleases = 1000

BEGIN TRAN

-- Заполнение таблицы Companies

SET @i=0

SET @RowCount=1

SET @MinNumberSymbols=5

SET @MaxNumberSymbols=50

WHILE @RowCount <= @NumberCompanies

BEGIN

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name = ''

WHILE @i <= @NameLimit

BEGIN

SET @Position = RAND() * 52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

INSERT INTO dbo.Companies(NameOfCompany) SELECT @Name

SET @RowCount += 1

END

-- Заполнение таблицы ProductionTypes

SET @i=0

SET @RowCount=1

SET @MinNumberSymbols=5

SET @MaxNumberSymbols=50

WHILE @RowCount <= @NumberProductionTypes

BEGIN

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name = ''

WHILE @i <= @NameLimit

BEGIN

SET @Position=RAND()*52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name1 = ''

WHILE @i <= @NameLimit

BEGIN

SET @Id=RAND()*52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

INSERT INTO dbo.ProductionTypes(ProductionType) SELECT @Name

SET @RowCount += 1

END

--Productions

SET @i=0

SET @RowCount=1

SET @MinNumberSymbols=5

SET @MaxNumberSymbols=50

WHILE @RowCount <= @NumberProductions

BEGIN

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name = ''

WHILE @i <= @NameLimit

BEGIN

SET @Position=RAND()*52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

SET @feature=RAND()*100

SET @Id = CAST( (1+RAND()*(@NumberProductions-1)) as int)

INSERT INTO dbo.Productions(ProductionName, ProductionTypeUnit, TypeID, Features) SELECT @Name, @TypeUnit, @Id, @feature

SET @RowCount += 1

END

--Outputs

SET @i=0

SET @RowCount=1

SET @MinNumberSymbols=5

SET @MaxNumberSymbols=50

WHILE @RowCount <= @NumberOutputs

BEGIN

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name = ''

WHILE @i <= @NameLimit

BEGIN

SET @Position=RAND()*52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

SET @Year=CAST( (RAND()*1990+30)as int) 

SET @Id = CAST( (1+RAND()*(@NumberOutputs-1)) as int)

SET @Number = CAST( (1+RAND()*(@NumberProductions-1)) as int)

INSERT INTO dbo.Outputs(CompanyID, ProductionID, OutputPlan, OutputFact, OutputYear) SELECT  @CompanyId, @ProductionId, @OPlan, @OFact, @Year

SET @RowCount += 1

END

--Releases

SET @i=0

SET @RowCount=1

SET @MinNumberSymbols=5

SET @MaxNumberSymbols=50

WHILE @RowCount <= @NumberReleases

BEGIN

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name = ''

WHILE @i <= @NameLimit

BEGIN

SET @Quarter=RAND()*52

SET @Name = @Name + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

SET @NameLimit=@MinNumberSymbols+RAND()*(@MaxNumberSymbols-@MinNumberSymbols)

SET @i=1

SET @Name1 = ''

WHILE @i <= @NameLimit

BEGIN

SET @Position=RAND()*52

SET @Name1 = @Name1 + SUBSTRING(@Symbol, @Position, 1)

SET @i=@i+1

END

SET @Year=CAST( (RAND()*1990+30)as int)

SET @Id = CAST( (1+RAND()*(@NumberReleases-1)) as int)

INSERT INTO dbo.Releases(CompanyID, ProductionID, ReleasesPlan, ReleasesFact, ReleaseYear) SELECT @CompanyId, @ProductionId, @RPlan, @RFact, @Year

SET @RowCount += 1

END

COMMIT TRAN