/* DROP TABLE participants; */

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
    duration INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS participants
(
    id INT AUTO_INCREMENT,
    profileId VARCHAR(255) NOT NULL,
    challengeId VARCHAR(255) NOT NULL,
    pendingAddToChallenge TINYINT DEFAULT 1,
    addedToChallenge TINYINT DEFAULT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS ruleDetails
(
    id INT AUTO_INCREMENT,
    challengeId VARCHAR(255) NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    minPoint INT NOT NULL,
    maxPoint INT NOT NULL,
    PRIMARY KEY (id)
);