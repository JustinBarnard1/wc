/* DROP TABLE dpoints;
DROP TABLE participants;
DROP TABLE rules;
DROP TABLE challenges; */

CREATE TABLE IF NOT EXISTS profiles
(
    id VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    name VARCHAR(255),
    picture VARCHAR(255),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS challenges
(
    id INT AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    startDate DATE NOT NULL,
    endDate DATE NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    joinable TINYINT DEFAULT 0,
    hasStarted TINYINT DEFAULT 0,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS participants
(
    id INT AUTO_INCREMENT,
    profileId VARCHAR(255) NOT NULL,
    challengeId INT NOT NULL,
    pendingAddToChallenge TINYINT DEFAULT 1,
    addedToChallenge TINYINT DEFAULT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS rules
(
    id INT AUTO_INCREMENT,
    challengeId VARCHAR(255) NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    minPoint INT NOT NULL,
    maxPoint INT NOT NULL,
    weekly TINYINT NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS dpoints
(
    id INT AUTO_INCREMENT,
    challengeId VARCHAR(255) NOT NULL,
    participantId VARCHAR(255) NOT NULL,
    profileId VARCHAR(255) NOT NULL,
    theDay DATE NOT NULL,
    points INT NOT NULL DEFAULT 0,
    PRIMARY KEY (id)
);