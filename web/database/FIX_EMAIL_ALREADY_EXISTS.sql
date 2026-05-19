-- Optional repair script if your database has old blank usernames.
-- Run this once in phpMyAdmin if you still get duplicate username/email problems.

UPDATE users
SET email = LOWER(TRIM(email))
WHERE email IS NOT NULL;

UPDATE users
SET username = CONCAT('user', id)
WHERE username IS NULL OR TRIM(username) = '';

UPDATE users u
SET username = CONCAT(
    LEFT(REPLACE(REPLACE(SUBSTRING_INDEX(u.email, '@', 1), '.', ''), '-', ''), 45),
    u.id
)
WHERE u.username IS NULL OR TRIM(u.username) = '';
