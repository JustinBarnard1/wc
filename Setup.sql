DROP TABLE challenges;

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