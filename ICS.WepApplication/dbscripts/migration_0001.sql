-- Table: domain."Aliens"
-- Table: domain."Contacts"
-- Table: domain."Passports"
-- Table: domain."Documents"
-- Table: domain."Employees"
-- Table: domain."Invitations"
-- Table: domain."VisitDetails"
-- Table: domain."Organizations"
-- Table: domain."StateRegistrations"
-- Table: domain."ForeignParticipants"

DROP TABLE IF EXISTS "system"."Users" CASCADE;
DROP TABLE IF EXISTS "system"."Profiles" CASCADE;

DROP TABLE IF EXISTS domain."Aliens";
DROP TABLE IF EXISTS domain."Contacts";
DROP TABLE IF EXISTS domain."Employees";
DROP TABLE IF EXISTS domain."Documents";
DROP TABLE IF EXISTS domain."Passports";
DROP TABLE IF EXISTS domain."VisitDetails";
DROP TABLE IF EXISTS domain."Organizations";
DROP TABLE IF EXISTS domain."StateRegistrations";
DROP TABLE IF EXISTS domain."ForeignParticipants";
DROP TABLE IF EXISTS domain."Invitations";

DROP SCHEMA IF EXISTS domain;
DROP SCHEMA IF EXISTS system;

SET default_tablespace = pg_default;

CREATE SCHEMA IF NOT EXISTS domain;
CREATE SCHEMA IF NOT EXISTS system;

--  1: Государственные регистрации
CREATE TABLE IF NOT EXISTS domain."StateRegistrations"
(
    "Uid" uuid NOT NULL,
	"INN" varchar(100) NOT NULL,
	"OGRNIP" varchar(100) NOT NULL,
    CONSTRAINT "StateRegistrations_pkey" PRIMARY KEY ("Uid")
);

--  2: Контакты
CREATE TABLE IF NOT EXISTS domain."Contacts"
(
    "Uid" uuid NOT NULL,
	"Email" varchar(100) NOT NULL,
	"Postcode" varchar(100) NOT NULL,
	"HomePhoneNumber" varchar(100) NOT NULL,
	"WorkPhoneNumber" varchar(100) NOT NULL,
	"MobilePhoneNumber" varchar(100) NOT NULL,
    CONSTRAINT "Contacts_pkey" PRIMARY KEY ("Uid")
);

--  3: Паспорта
CREATE TABLE IF NOT EXISTS domain."Passports"
(
    "Uid" uuid NOT NULL,
	"NameRus" varchar(250) NOT NULL,
	"NameEng" varchar(250) NOT NULL,
	"SurnameRus" varchar(250) NOT NULL,
	"SurnameEng" varchar(250) NOT NULL,
	"PatronymicNameRus" varchar(250) NOT NULL,
	"PatronymicNameEng" varchar(250) NOT NULL,
	"BirthPlace" varchar(250) NOT NULL,
	"BirthCountry" varchar(250) NOT NULL,
	"Citizenship" varchar(250) NOT NULL,
	"IdentityDocument" varchar(250) NOT NULL,
	"IssuePlace" varchar(250) NOT NULL,
	"DepartmentCode" varchar(250) NOT NULL,
	"Residence" varchar(250) NOT NULL,
	"ResidenceRegion" varchar(250) NOT NULL,
	"ResidenceCountry" varchar(250) NOT NULL,
	"BirthDate" timestamp NULL,
	"IssueDate" timestamp NULL,
	"Gender" integer NULL,
    CONSTRAINT "Passports_pkey" PRIMARY KEY ("Uid")
);

--  4: Организации
CREATE TABLE IF NOT EXISTS domain."Organizations"
(
    "Uid" uuid NOT NULL,
	"StateRegistrationUid" uuid NOT NULL,
	"Name" varchar(250) NOT NULL,
	"ShortName" varchar(250) NOT NULL,
	"LegalAddress" varchar(250) NOT NULL,
	"ScientificActivity" varchar(250) NOT NULL,
    CONSTRAINT "Organizations_pkey" PRIMARY KEY ("Uid")
);

--  5: Сотрудники
CREATE TABLE IF NOT EXISTS domain."Employees"
(
    "Uid" uuid NOT NULL,
	"UserUid" uuid NOT NULL,
	"InvitationUid" uuid NULL,
	"ContactUid" uuid NULL,
	"ManagerUid" uuid NULL,
	"PassportUid" uuid NULL,
	"OrganizationUid" uuid NULL,
	"StateRegistrationUid" uuid NULL,
	"AcademicDegree" varchar(250) NULL,
	"AcademicRank" varchar(250) NULL,
	"Education" varchar(250) NULL,
	"Position" varchar(250) NULL,
	"WorkPlace" varchar(250) NULL,
    CONSTRAINT "Employees_pkey" PRIMARY KEY ("Uid"),
	CONSTRAINT "Employees_Managers_fkey" FOREIGN KEY ("ManagerUid")
        REFERENCES domain."Employees" ("Uid") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

--  6: Детали визита
CREATE TABLE IF NOT EXISTS domain."VisitDetails"
(
    "Uid" uuid NOT NULL,
	"InvitationUid" uuid NOT NULL,
	"Goal" varchar(250) NOT NULL,
	"Country" varchar(250) NOT NULL,
	"VisaType" varchar(250) NOT NULL,
	"VisaCity" varchar(250) NOT NULL,
	"VisaCountry" varchar(250) NOT NULL,
	"VisitingPoints" varchar(250) NOT NULL,
	"PeriodDays" integer NOT NULL,
	"VisaMultiplicity" integer NOT NULL,
	"ArrivalDate" timestamp NOT NULL,
	"DepartureDate" timestamp NOT NULL,
    CONSTRAINT "VisitDetails_pkey" PRIMARY KEY ("Uid")
);

--  7: Иностранцы
CREATE TABLE IF NOT EXISTS domain."Aliens"
(
    "AlienUid" uuid NOT NULL,
    "ContactUid" uuid NOT NULL,
	"PassportUid" uuid NOT NULL,
	"InvitationUid" uuid NOT NULL,
    "OrganizationUid" uuid NOT NULL,
	"StateRegistrationUid" uuid NOT NULL,
	"Position" varchar(100) NOT NULL,
	"WorkPlace" varchar(100) NOT NULL,
	"WorkAddress" varchar(250) NOT NULL,
	"StayAddress" varchar(250) NOT NULL,
    CONSTRAINT "Aliens_pkey" PRIMARY KEY ("AlienUid")
);

--  8: Приглашения
CREATE TABLE IF NOT EXISTS domain."Invitations"
(
    "Uid" uuid NOT NULL,
    "AlienUid" uuid NOT NULL,
	"EmployeeUid" uuid NOT NULL,
    "VisitDetailUid" uuid NOT NULL,
	"CreatedDate" timestamp NOT NULL,
	"UpdateDate" timestamp NOT NULL,
	"Status" integer NOT NULL,
    CONSTRAINT "Invitations_pkey" PRIMARY KEY ("Uid")
);

--  9: Иностранные участники
CREATE TABLE IF NOT EXISTS domain."ForeignParticipants"
(
    "Uid" uuid NOT NULL,
	"AlienUid" uuid NOT NULL,
	"InvitationUid" uuid NOT NULL,
	"PassportUid" uuid NOT NULL,
    CONSTRAINT "ForeignParticipants_pkey" PRIMARY KEY ("Uid"),
	CONSTRAINT "ForeignParticipants_Invitations_fkey" FOREIGN KEY ("InvitationUid")
        REFERENCES domain."Invitations" ("Uid") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

--  10: Документы
CREATE TABLE IF NOT EXISTS domain."Documents"
(
    "Uid" uuid NOT NULL,
	"InvitationUid" uuid NOT NULL,
	"Name" varchar(250) NOT NULL,
	"Content" bytea NOT NULL,
	"UpdateDate" timestamp NOT NULL,
	"CreatedDate" timestamp NOT NULL,
	"DocumentType" integer NOT NULL,
    CONSTRAINT "Documents_pkey" PRIMARY KEY ("Uid"),
    CONSTRAINT "Documents_Invitations_fkey" FOREIGN KEY ("InvitationUid")
        REFERENCES domain."Invitations" ("Uid") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

--  11: Пользователи
CREATE TABLE IF NOT EXISTS "system"."Users"
(
    "Uid" uuid NOT NULL,
	"Account" varchar(250) NOT NULL,
	"Password" varchar(100) NOT NULL,
	"ProfileUid" uuid NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY ("Uid")
);

--  12: Пользовательские профили
CREATE TABLE IF NOT EXISTS "system"."Profiles"
(
    "Uid" uuid NOT NULL,
	"OrdinalNumber" bigint NOT NULL,
	"Avatar" bytea NULL,
	"WebPages" text NULL,
	"UserUid" uuid Not NULL,
    CONSTRAINT "Profiles_pkey" PRIMARY KEY ("Uid"),
	CONSTRAINT "Profiles_Users_fkey" FOREIGN KEY ("UserUid")
        REFERENCES "system"."Users" ("Uid") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

-- Set the postgres owner for tables:
ALTER TABLE "system"."Users" OWNER to postgres;
ALTER TABLE "system"."Profiles" OWNER to postgres;
ALTER TABLE domain."Aliens" OWNER to postgres;
ALTER TABLE domain."Contacts" OWNER to postgres;
ALTER TABLE domain."Documents" OWNER to postgres;
ALTER TABLE domain."Employees" OWNER to postgres;
ALTER TABLE domain."Passports" OWNER to postgres;
ALTER TABLE domain."Invitations" OWNER to postgres;
ALTER TABLE domain."VisitDetails" OWNER to postgres;
ALTER TABLE domain."Organizations" OWNER to postgres;
ALTER TABLE domain."StateRegistrations" OWNER to postgres;
ALTER TABLE domain."ForeignParticipants" OWNER to postgres;

-- Set comments:
COMMENT ON TABLE "system"."Users" IS 'Пользователи';
COMMENT ON TABLE "system"."Profiles" IS 'Профили';
COMMENT ON TABLE domain."Aliens" IS 'Иностранцы';
COMMENT ON TABLE domain."Contacts" IS 'Контакты';
COMMENT ON TABLE domain."Documents" IS 'Документы';
COMMENT ON TABLE domain."Employees" IS 'Сотрудники';
COMMENT ON TABLE domain."Passports" IS 'Паспорта';
COMMENT ON TABLE domain."Invitations" IS 'Приглашения';
COMMENT ON TABLE domain."VisitDetails" IS 'Детали визита';
COMMENT ON TABLE domain."Organizations" IS 'Организации';
COMMENT ON TABLE domain."StateRegistrations" IS 'Государственные регистрации';
COMMENT ON TABLE domain."ForeignParticipants" IS 'Иностранные участники';

COMMENT ON CONSTRAINT "Employees_Managers_fkey" ON domain."Employees"
    IS 'Связь таблицы Сотрудники с таблицей Паспорта';
	
COMMENT ON CONSTRAINT "ForeignParticipants_Invitations_fkey" ON domain."ForeignParticipants"
    IS 'Связь таблицы Иностранные участники с таблицей Приглашения';