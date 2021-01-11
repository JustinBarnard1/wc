-- DROP TABLE participants;

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
    totalPoints INT DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    isAllowed TINYINT,
    PRIMARY KEY (id)
);