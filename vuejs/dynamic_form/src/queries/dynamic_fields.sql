create table FieldDefinition (
    Id            int identity primary key,
    EntityType    nvarchar(50)  not null,   -- 'Prospect' | 'Destination'
    FieldKey      nvarchar(100) not null,   -- es. 'vecdsrso'
    Label         nvarchar(100) not null,
    Placeholder   nvarchar(100) null,
    ControlType   nvarchar(50)  not null,   -- text, number, date, select, textarea, checkbox
    IsRequired    bit           not null default 0,
    IsVisible     bit           not null default 1,
    SortOrder     int           not null default 0,
    Section       nvarchar(100) null,
    Validation    nvarchar(max) null,       -- JSON: {"maxLength":50,"min":0}
    IsSystem      bit           not null default 0,
    OptionsSource nvarchar(200) null,       -- nome logico della lista esterna (select)
    constraint UQ_FieldDefinition unique (EntityType, FieldKey),
    constraint CK_FieldDefinition_EntityType
        check (EntityType in ('Prospect', 'Destination')),
    constraint CK_FieldDefinition_ControlType
        check (ControlType in ('text', 'number', 'date', 'select', 'textarea', 'checkbox')),
    constraint CK_FieldDefinition_Validation
        check (Validation is null or isjson(Validation) = 1)
);

create table FieldOption (
    Id         int identity primary key,
    FieldId    int           not null references FieldDefinition(Id),
    Value      nvarchar(100) not null,
    Label      nvarchar(100) not null,
    SortOrder  int           not null default 0,
    IsActive   bit           not null default 1,
    constraint UQ_FieldOption unique (FieldId, Value)
);


INSERT INTO FieldDefinition
    (EntityType, FieldKey, Label, Placeholder, ControlType,
     IsRequired, IsVisible, SortOrder, Section, Validation, IsSystem, OptionsSource)
VALUES
('Prospect', 'vecdsrso', 'Ragione sociale', 'Ragione sociale', 'text', 1, 1, 1, 'Anagrafica', '{"maxLength":100}', 1, NULL),
('Prospect', 'vecdsind', 'Indirizzo', 'Via e numero', 'text', 0, 1, 2, 'Anagrafica', '{"maxLength":100}', 1, NULL),
('Prospect', 'veccdcap', 'CAP', '00000', 'text', 0, 1, 3, 'Anagrafica', '{"pattern":"^[0-9]{5}$","message":"Il CAP deve avere 5 cifre"}', 1, NULL),
('Prospect', 'vecdsloc', 'Località', 'Località', 'text', 0, 1, 4, 'Anagrafica', '{"maxLength":100}', 1, NULL),
('Prospect', 'veccdpro', 'Provincia', 'BG', 'text', 0, 1, 5, 'Anagrafica', '{"maxLength":2}', 1, NULL),
('Prospect', 'veccdiva', 'Partita IVA', '11 cifre', 'text', 0, 1, 6, 'Fiscale', '{"pattern":"^[0-9]{11}$","message":"Deve contenere 11 cifre"}', 1, NULL),
('Prospect', 'veccdfis', 'Codice fiscale', 'Codice fiscale', 'text', 0, 1, 7, 'Fiscale', '{"maxLength":16}', 1, NULL),
('Prospect', 'veccdpag', 'Modalità di pagamento', 'Seleziona...', 'select', 0, 1, 8, 'Fiscale', NULL, 1, 'pagamenti'),
('Prospect', 'vecswConai_Polieco', 'Aderente Conai/Polieco', NULL, 'checkbox', 0, 1, 9, 'Fiscale', NULL, 1, NULL),
('Prospect', 'vecdstel', 'Telefono', 'Telefono', 'text', 0, 1, 10, 'Contatti', NULL, 1, NULL),
('Prospect', 'vecdscel', 'Cellulare', 'Cellulare', 'text', 0, 1, 11, 'Contatti', NULL, 1, NULL),
('Prospect', 'vecdsemail', 'Email', 'nome@dominio.it', 'text', 0, 1, 12, 'Contatti', '{"pattern":"^[^@]+@[^@]+\\.[^@]+$","message":"Email non valida"}', 1, NULL);

INSERT INTO FieldDefinition
    (EntityType, FieldKey, Label, Placeholder, ControlType,
     IsRequired, IsVisible, SortOrder, Section, Validation, IsSystem, OptionsSource)
VALUES
('Destination', 'vecdsrso', 'Ragione sociale', 'Ragione sociale', 'text', 1, 1, 1, NULL, '{"maxLength":100}', 1, NULL),
('Destination', 'vecdsind', 'Indirizzo', 'Via e numero', 'text', 0, 1, 2, NULL, '{"maxLength":100}', 1, NULL),
('Destination', 'vecdsloc', 'Località', 'Località', 'text', 0, 1, 3, NULL, NULL, 1, NULL),
('Destination', 'veccdcap', 'CAP', '00000', 'text', 0, 1, 4, NULL, '{"pattern":"^[0-9]{5}$","message":"Il CAP deve avere 5 cifre"}', 1, NULL),
('Destination', 'veccdpro', 'Provincia', 'BG', 'text', 0, 1, 5, NULL, '{"maxLength":2}', 1, NULL),
('Destination', 'vecdstel', 'Telefono', 'Telefono', 'text', 0, 1, 6, NULL, NULL, 1, NULL),
('Destination', 'vecdscel', 'Cellulare', 'Cellulare', 'text', 0, 1, 7, NULL, NULL, 1, NULL);

INSERT INTO FieldDefinition
    (EntityType, FieldKey, Label, Placeholder, ControlType,
     IsRequired, IsVisible, SortOrder, Section, Validation, IsSystem, OptionsSource)
VALUES
('Prospect', 'tipoCliente', 'Tipo cliente', 'Seleziona...', 'select', 1, 1, 13, 'Anagrafica', NULL, 0, NULL);

DECLARE @fieldId int = SCOPE_IDENTITY();

INSERT INTO FieldOption (FieldId, Value, Label, SortOrder, IsActive)
VALUES
(@fieldId, 'PRIV', 'Privato', 1, 1),
(@fieldId, 'AZ', 'Azienda', 2, 1),
(@fieldId, 'PA', 'Pubblica amministrazione', 3, 1);
