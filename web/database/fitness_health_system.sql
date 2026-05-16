CREATE DATABASE IF NOT EXISTS fitness_health_system;
USE fitness_health_system;

CREATE TABLE IF NOT EXISTS members (
    member_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    age INT NOT NULL,
    gender VARCHAR(20) NOT NULL,
    contact_number VARCHAR(30),
    address TEXT,
    membership_type VARCHAR(50) DEFAULT 'Regular',
    date_registered DATE NOT NULL DEFAULT (CURRENT_DATE)
);

CREATE TABLE IF NOT EXISTS health_records (
    record_id INT AUTO_INCREMENT PRIMARY KEY,
    member_id INT NOT NULL,
    height DECIMAL(5,2) NOT NULL,
    weight DECIMAL(5,2) NOT NULL,
    bmi DECIMAL(5,2) NOT NULL,
    bmi_category VARCHAR(50) NOT NULL,
    systolic INT NOT NULL,
    diastolic INT NOT NULL,
    bp_status VARCHAR(80) NOT NULL,
    heart_rate INT,
    remarks TEXT,
    date_checked DATE NOT NULL DEFAULT (CURRENT_DATE),
    FOREIGN KEY (member_id) REFERENCES members(member_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS fitness_goals (
    goal_id INT AUTO_INCREMENT PRIMARY KEY,
    member_id INT NOT NULL,
    goal_type VARCHAR(100) NOT NULL,
    target_weight DECIMAL(5,2),
    target_date DATE,
    status VARCHAR(50) DEFAULT 'Ongoing',
    notes TEXT,
    FOREIGN KEY (member_id) REFERENCES members(member_id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS workout_plans (
    plan_id INT AUTO_INCREMENT PRIMARY KEY,
    member_id INT NOT NULL,
    plan_name VARCHAR(100) NOT NULL,
    description TEXT,
    difficulty_level VARCHAR(50) DEFAULT 'Beginner',
    assigned_date DATE NOT NULL DEFAULT (CURRENT_DATE),
    FOREIGN KEY (member_id) REFERENCES members(member_id) ON DELETE CASCADE
);

INSERT INTO members (full_name, age, gender, contact_number, address, membership_type, date_registered) VALUES
('Juan Dela Cruz', 24, 'Male', '09171234567', 'Manila', 'Regular', CURRENT_DATE),
('Maria Santos', 29, 'Female', '09181234567', 'Quezon City', 'Premium', CURRENT_DATE);

INSERT INTO health_records (member_id, height, weight, bmi, bmi_category, systolic, diastolic, bp_status, heart_rate, remarks, date_checked) VALUES
(1, 1.70, 68, 23.53, 'Normal weight', 118, 76, 'Normal', 72, 'Good condition', CURRENT_DATE),
(2, 1.58, 72, 28.84, 'Overweight', 135, 86, 'High blood pressure stage 1', 78, 'Needs diet and cardio plan', CURRENT_DATE);
