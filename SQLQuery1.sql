CREATE TABLE [dbo].[calificaciones] (
    [Idc]       INT,    
    [Matricula] BIGINT,
    [Clave]     SMALLINT,
    [Parcial1]  INT,
    [Parcial2]  INT,
    [parcial3]  INT,
    CONSTRAINT [pk_calificaciones] PRIMARY KEY CLUSTERED ([Idc] ASC),
    CONSTRAINT [fk_calificaciones_alumnos] FOREIGN KEY ([Matricula]) REFERENCES [dbo].[alumnos] ([Matricula]),
   CONSTRAINT [fk_calificaciones_docentes] FOREIGN KEY ([clave]) REFERENCES [dbo].[docentes] ([clave])

);