-- CREACIÓ DE LA BASE DE DADES "Db_Y"
DROP DATABASE IF EXISTS Db_Y;
CREATE DATABASE Db_Y;
USE Db_Y;

-- CREACIÓ DE LES TRES TAULES  "Usuari", "Publicacio" i "Comentari"
CREATE OR REPLACE TABLE Usuari(
    user_id int NOT NULL AUTO_INCREMENT,
    username varchar(20) NOT NULL,
    contrasenya varchar(30) NOT NULL,
    nom varchar(20) NOT NULL,
    cognom varchar(20) NULL,
    correu varchar(50) NOT NULL,
    telefon varchar(9) NULL,
    CONSTRAINT PK_Usuari PRIMARY KEY(user_id)
);
CREATE OR REPLACE TABLE Publicacio(
    publicacio_id int AUTO_INCREMENT,
    user_id int NOT NULL,
    data_p date NOT NULL,
    titol varchar(30) NOT NULL,
    contingut varchar(300) NOT NULL,
    CONSTRAINT PK_Publicacio PRIMARY KEY(publicacio_id, user_id),
    CONSTRAINT FK_Publicacio_Usuari FOREIGN KEY(user_id)
    REFERENCES Usuari(user_id)
);
CREATE OR REPLACE TABLE Comentari(
    comentari_id int NOT NULL AUTO_INCREMENT,
    user_id int NOT NULL,
    publicacio_id int NOT NULL,
    data_c date NOT NULL,
    contingut varchar(300) NOT NULL,
    CONSTRAINT PK_Comentari PRIMARY KEY(comentari_id, user_id, publicacio_id),
    CONSTRAINT FK_Comentari_Usuari FOREIGN KEY(user_id)
    REFERENCES Usuari(user_id),
    CONSTRAINT FK_Comentari_Publicacio FOREIGN KEY(publicacio_id)
    REFERENCES Publicacio(publicacio_id)
);
CREATE OR REPLACE TABLE Tag(
    tag_id int NOT NULL AUTO_INCREMENT,
    nom varchar(20) NOT NULL,
    CONSTRAINT PK_Tag PRIMARY KEY(tag_id)
);
CREATE OR REPLACE TABLE TagPublicacio(
    publicacio_id int NOT NULL,
    tag_id int NOT NULL,
    CONSTRAINT PK_TagPublicacio PRIMARY KEY(publicacio_id, tag_id),
    CONSTRAINT FK_TagPublicacio_Tag FOREIGN KEY(tag_id)
    REFERENCES Tag(tag_id),
    CONSTRAINT PL_TagPublicacio_Publicacio FOREIGN KEY(publicacio_id)
    REFERENCES Publicacio(publicacio_id)
);


-- INSERT INICIAL A LA TAULA "usuari"
INSERT INTO usuari (username, contrasenya, nom, cognom, correu, telefon)
	VALUES('rger9', 'rogerp', 'Roger', 'Palmada', 'roger.palmada@gmail.com', '633556238');
INSERT INTO usuari (username, contrasenya, nom, cognom, correu, telefon)
	VALUES('deprius', 'asdf1234', 'Oriol', 'Deprius', 'orioldeprius@gmail.com', '620392426');
INSERT INTO usuari (username, contrasenya, nom, cognom, correu, telefon)
	VALUES('pozok', 'sergig', 'Sergi', 'Garcia', 'sergi.garcia@gmail.com', '633333333');
INSERT INTO usuari (username, contrasenya, nom, cognom, correu, telefon)
	VALUES('cparra', 'claudiap', 'Claudia', 'Parra', 'claudia.parra@gmail.com', '655222111');

-- INSERT INICIAL A LA TAULA "publicacio"
INSERT INTO publicacio (user_id, data_p, titol, contingut)
	VALUES('4', '20240513', 'Quina desgracia!', "Avui se m'ha caigut el suc de prèssec dins el portàtil i ja no em funciona, algun consell gent? :(");
INSERT INTO publicacio (user_id, data_p, titol, contingut)
	VALUES('1', '20240523', 'Títol exemple', "Contingut interessant 1");
INSERT INTO publicacio (user_id, data_p, titol, contingut)
	VALUES('2', '20240520', 'Otru titol', "Contingut interessant 2");
INSERT INTO publicacio (user_id, data_p, titol, contingut)
	VALUES('3', '20240522', 'Canvis', "Faig canvis");

-- INSERT INICIAL A LA TAULA "comentari"
INSERT INTO comentari (user_id, publicacio_id, data_c, contingut)
	VALUES('1', '1', '20240513', 'Radical');
INSERT INTO comentari (user_id, publicacio_id, data_c, contingut)
	VALUES('2', '4', '20240523', 'Si que en fas');

-- INSERT INICIAL A LA TAULA "Tags"
INSERT INTO tag (nom)
	VALUES("Radical");
INSERT INTO tag (nom)
	VALUES("Fantasia");
INSERT INTO tag(nom)
	VALUES("Terror");

-- INSERT INICIAL A LA TAULA "Tagpublicacio"
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(1, 1);
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(1, 3);
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(2, 2);
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(2, 1);
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(3, 3);
INSERT INTO tagpublicacio (publicacio_id, tag_id)
	VALUES(4, 1);

-- TRIGGERS
DELIMITER //
CREATE OR REPLACE TRIGGER T_NoUsuariUpdate
	BEFORE UPDATE ON Usuari FOR EACH ROW
BEGIN 
	IF OLD.user_id <> NEW.user_id THEN 
		SIGNAL SQLSTATE 'HY000' SET message_text = "ERROR: No es pot modificar la ID d'usuari";
	END IF;
END
//
CREATE OR REPLACE TRIGGER T_BorrarEntradaTagPublicacio
	AFTER DELETE ON Publicacio FOR EACH ROW
BEGIN
	DELETE FROM tagpublicacio 
		WHERE publicacio_id = OLD.publicacio_id;
END
//
CREATE OR REPLACE TRIGGER T_BorrarTagSiSonZero
	AFTER DELETE ON tagpublicacio FOR EACH ROW
BEGIN
	DECLARE v_QuantitatTags int;
	
	SELECT COUNT(tag_id)
		INTO v_QuantitatTags
		WHERE tag_id = OLD.tag_id;
	
	IF v_QuantitatTags = 0 THEN
		DELETE FROM tag 
			WHERE tag_id = OLD.tag_id;
	END IF;
END
//
DELIMITER ;
