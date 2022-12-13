ALTER TABLE [dbo].[StrRozv]
ADD RivNb int NOT NULL DEFAULT 1,
RivGrf nvarchar(255) NOT NULL DEFAULT '.1';

-- PW-3
CREATE TABLE [SumRozv]
(
    [Id] int NOT NULL IDENTITY,
    [CdVyr] nvarchar(450) NOT NULL,
    [CdKp] nvarchar(450) NOT NULL,
    [SumKp] int NOT NULL,
    [MinRv] int NOT NULL,
    [CdTp] int NOT NULL,
    CONSTRAINT [PK_SumRozv] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SumRozv_GLPR_CdKp] FOREIGN KEY ([CdKp]) REFERENCES [GLPR] ([CdPr]),
    CONSTRAINT [FK_SumRozv_GLPR_CdVyr] FOREIGN KEY ([CdVyr]) REFERENCES [GLPR] ([CdPr]),
    CONSTRAINT [FK_SumRozv_TypePr_CdTp] FOREIGN KEY ([CdTp]) REFERENCES [TypePr] ([CdTp])
);

INSERT INTO SumRozv
    (CdVyr, CdKp, SumKp, MinRv, CdTp)
SELECT CdVyr, CdKp, SUM(QtyKp) as SumKp, MAX(RivNb) as MinRiv, MAX(CdTp) as CdTp
FROM StrRozv, GLPR
WHERE (StrRozv.CdKp = GLPR.CdPr)
GROUP BY CdVyr, CdKp
ORDER BY CdVyr;

--PW-5
CREATE TABLE [DovMt]
(
    [CdMt] nvarchar(450) NOT NULL,
    [NmMt] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DovMt] PRIMARY KEY ([CdMt])
);

CREATE TABLE [ZastMt]
(
    [CdKp] nvarchar(450) NOT NULL,
    [CdMt] nvarchar(450) NOT NULL,
    [OdVym] nvarchar(max) NOT NULL,
    [QtyMt] real NOT NULL,
    CONSTRAINT [PK_ZastMt] PRIMARY KEY ([CdKp], [CdMt]),
    CONSTRAINT [FK_ZastMt_DovMt_CdMt] FOREIGN KEY ([CdMt]) REFERENCES [DovMt] ([CdMt]),
    CONSTRAINT [FK_ZastMt_GLPR_CdKp] FOREIGN KEY ([CdKp]) REFERENCES [GLPR] ([CdPr])
);

--PW-6

CREATE TABLE [DovTO]
(
    [CdTO] nvarchar(450) NOT NULL,
    [NmTO] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_DovTO] PRIMARY KEY ([CdTO]),
    CONSTRAINT [AK_DovTO_NmTO] UNIQUE ([NmTO])
);

CREATE TABLE [PTRN]
(
    [CdPr] nvarchar(450) NOT NULL,
    [CdTO] nvarchar(450) NOT NULL,
    [NbTO] nvarchar(max) NOT NULL,
    [Godin] real NOT NULL,
    CONSTRAINT [PK_PTRN] PRIMARY KEY ([CdPr], [CdTO]),
    CONSTRAINT [AK_PTRN_CdTO] UNIQUE ([CdTO]),
    CONSTRAINT [FK_PTRN_DovTO_CdTO] FOREIGN KEY ([CdTO]) REFERENCES [DovTO] ([CdTO]),
    CONSTRAINT [FK_PTRN_GLPR_CdPr] FOREIGN KEY ([CdPr]) REFERENCES [GLPR] ([CdPr])
);

CREATE TABLE [TechNorm]
(
    [CdVyr] nvarchar(450) NOT NULL,
    [CdTO] nvarchar(450) NOT NULL,
    [NmTO] nvarchar(450) NOT NULL,
    [SumGodin] real NOT NULL,
    [SumRozvId] int NULL,
    CONSTRAINT [PK_TechNorm] PRIMARY KEY ([CdVyr], [CdTO]),
    CONSTRAINT [FK_TechNorm_DovTO_NmTO] FOREIGN KEY ([NmTO]) REFERENCES [DovTO] ([NmTO]),
    CONSTRAINT [FK_TechNorm_PTRN_CdTO] FOREIGN KEY ([CdTO]) REFERENCES [PTRN] ([CdTO]),
    CONSTRAINT [FK_TechNorm_SumRozv_SumRozvId] FOREIGN KEY ([SumRozvId]) REFERENCES [SumRozv] ([Id])
);

--PW-7
CREATE TABLE [DovPrf]
(
    [CdPf] real NOT NULL,
    [NmPf] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_DovPrf] PRIMARY KEY ([CdPf])
);

CREATE TABLE [TO_PF]
(
    [CdTO] nvarchar(450) NOT NULL,
    [CdPf] real NOT NULL,
    CONSTRAINT [PK_TO_PF] PRIMARY KEY ([CdTO], [CdPf]),
    CONSTRAINT [FK_TO_PF_DovPrf_CdPf] FOREIGN KEY ([CdPf]) REFERENCES [DovPrf] ([CdPf]) ON DELETE CASCADE,
    CONSTRAINT [FK_TO_PF_DovTO_CdTO] FOREIGN KEY ([CdTO]) REFERENCES [DovTO] ([CdTO]) ON DELETE CASCADE
);