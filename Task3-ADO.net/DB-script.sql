-- Таблиця користувачів
CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    date_of_birth DATE,
    gender VARCHAR(10),
    interests TEXT[],
    is_authorized BOOLEAN DEFAULT FALSE
);

-- Таблиця дошок подарунків
CREATE TABLE giftboards (
    board_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES Users(user_id) ON DELETE CASCADE,
    name VARCHAR(100) NOT NULL,
    celebration_date DATE,
    collaborators INT[],  -- Змінив тип даних, щоб уникнути помилок
    access_level VARCHAR(10) CHECK (access_level IN ('public', 'friends_only', 'private')),
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Таблиця подарунків
CREATE TABLE gifts (
    gift_id SERIAL PRIMARY KEY,
    board_id INT REFERENCES GiftBoards(board_id) ON DELETE CASCADE,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    link VARCHAR(255),
    image_url VARCHAR(255),
    is_reserved BOOLEAN DEFAULT FALSE,
    reserved_by INT REFERENCES Users(user_id) ON DELETE SET NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Таблиця резервувань подарунків
CREATE TABLE giftreservations (
    reservation_id SERIAL PRIMARY KEY,
    gift_id INT REFERENCES Gifts(gift_id) ON DELETE CASCADE,
    user_id INT REFERENCES Users(user_id) ON DELETE CASCADE,
    reserved_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(gift_id, user_id)  -- Забезпечує, що один подарунок може бути зарезервований лише одним користувачем
);

-- Таблиця журналу дій (логів) для аудиту
CREATE TABLE actionLogs (
    log_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES Users(user_id) ON DELETE SET NULL,
    action VARCHAR(255),
    action_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Таблиця для підтвердження реєстрації (email confirmation)
CREATE TABLE emailconfirmations (
    confirmation_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES Users(user_id) ON DELETE CASCADE,
    confirmation_token VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    expires_at TIMESTAMP NOT NULL
);