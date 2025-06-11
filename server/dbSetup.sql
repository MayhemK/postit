CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE albums (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    title TINYTEXT NOT NULL,
    description TEXT,
    cover_img TEXT NOT NULL,
    archived BOOLEAN NOT NULL DEFAULT false,
    category ENUM(
        'aesthetics',
        'food',
        'games',
        'animals',
        'vibes',
        'misc'
    ),
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE images (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    creator_id VARCHAR(255) NOT NULL,
    album_id INT NOT NULL,
    img_url TEXT NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE,
    FOREIGN KEY (album_id) REFERENCES albums (id) ON DELETE CASCADE
);

DROP TABLE images;

CREATE TABLE watchers (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    account_id VARCHAR(255) NOT NULL,
    album_id INT NOT NULL,
    FOREIGN KEY (account_id) REFERENCES accounts (id) ON DELETE CASCADE,
    FOREIGN KEY (album_id) REFERENCES albums (id) ON DELETE CASCADE,
    UNIQUE (account_id, album_id)
);

SELECT albums.*, accounts.*
FROM albums
    INNER JOIN accounts on accounts.id = albums.creator_id
ORDER BY albums.created_at DESC;

DELETE FROM watchers;

SELECT * FROM watchers WHERE id = 40

SELECT id, album_id, account_id FROM watchers;

ALTER TABLE albums MODIFY COLUMN watcher_count INT DEFAULT 0;

SELECT images.*, accounts.*
FROM images
    JOIN accounts ON image.creatorId = account.id
WHERE
    image.id = 21;

SELECT images.*, accounts.*
FROM images
    INNER JOIN accounts ON accounts.id = images.creator_id
WHERE
    images.album_id = @albumId;