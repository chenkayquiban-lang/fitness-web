CREATE DATABASE IF NOT EXISTS fitlife_db;
USE fitlife_db;

DROP TABLE IF EXISTS community_comments, community_posts, meal_planner, recipes, health_records, activity_logs, goals, class_bookings, classes, payments, subscription_plans, medical_histories, members, trainers, users;

CREATE TABLE users(
 id INT AUTO_INCREMENT PRIMARY KEY,
 full_name VARCHAR(120) NOT NULL,
 username VARCHAR(60) NULL UNIQUE,
 email VARCHAR(120) NOT NULL UNIQUE,
 password VARCHAR(255) NOT NULL,
 role ENUM('user') NOT NULL DEFAULT 'user',
 status ENUM('active','inactive') DEFAULT 'active',
 created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE members(
 id INT AUTO_INCREMENT PRIMARY KEY,
 user_id INT NOT NULL,
 phone VARCHAR(30), address VARCHAR(255), gender VARCHAR(20), birthday DATE,
 height_cm DECIMAL(6,2), weight_kg DECIMAL(6,2), goal VARCHAR(100), level_points INT DEFAULT 0,
 FOREIGN KEY(user_id) REFERENCES users(id) ON DELETE CASCADE
);
CREATE TABLE trainers(
 id INT AUTO_INCREMENT PRIMARY KEY,
 user_id INT NOT NULL, specialty VARCHAR(120), schedule VARCHAR(255), rating DECIMAL(3,2) DEFAULT 5,
 FOREIGN KEY(user_id) REFERENCES users(id) ON DELETE CASCADE
);
CREATE TABLE medical_histories(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, allergies TEXT, conditions TEXT, medications TEXT, notes TEXT,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE
);
CREATE TABLE subscription_plans(
 id INT AUTO_INCREMENT PRIMARY KEY,
 plan_name VARCHAR(80), duration_months INT, price DECIMAL(10,2), description TEXT
);
CREATE TABLE payments(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, plan_id INT NOT NULL, amount DECIMAL(10,2), payment_date DATE, due_date DATE,
 status ENUM('paid','pending','overdue') DEFAULT 'paid', invoice_no VARCHAR(40),
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE,
 FOREIGN KEY(plan_id) REFERENCES subscription_plans(id)
);
CREATE TABLE classes(
 id INT AUTO_INCREMENT PRIMARY KEY,
 trainer_id INT, title VARCHAR(120), class_type VARCHAR(80), schedule_datetime DATETIME, capacity INT, stream_link VARCHAR(255), description TEXT,
 FOREIGN KEY(trainer_id) REFERENCES trainers(id) ON DELETE SET NULL
);
CREATE TABLE class_bookings(
 id INT AUTO_INCREMENT PRIMARY KEY,
 class_id INT NOT NULL, member_id INT NOT NULL, status ENUM('booked','attended','cancelled') DEFAULT 'booked', booked_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
 FOREIGN KEY(class_id) REFERENCES classes(id) ON DELETE CASCADE,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE
);
CREATE TABLE goals(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, title VARCHAR(120), target_value DECIMAL(8,2), current_value DECIMAL(8,2), unit VARCHAR(40), target_date DATE,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE
);
CREATE TABLE activity_logs(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, log_date DATE, steps INT DEFAULT 0, workout VARCHAR(120), calories_burned INT DEFAULT 0, weight_kg DECIMAL(6,2), notes TEXT,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE
);
CREATE TABLE health_records(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, record_date DATE, systolic INT, diastolic INT, heart_rate INT, temperature DECIMAL(4,1), blood_sugar DECIMAL(6,2), oxygen_level INT, weight_kg DECIMAL(6,2), bmi DECIMAL(5,2), status VARCHAR(120), notes TEXT,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE
);
CREATE TABLE recipes(
 id INT AUTO_INCREMENT PRIMARY KEY,
 name VARCHAR(120), goal VARCHAR(80), calories INT, protein DECIMAL(6,2), carbs DECIMAL(6,2), fats DECIMAL(6,2), ingredients TEXT, instructions TEXT
);
CREATE TABLE meal_planner(
 id INT AUTO_INCREMENT PRIMARY KEY,
 member_id INT NOT NULL, plan_date DATE, meal_type VARCHAR(40), recipe_id INT,
 FOREIGN KEY(member_id) REFERENCES members(id) ON DELETE CASCADE,
 FOREIGN KEY(recipe_id) REFERENCES recipes(id) ON DELETE SET NULL
);
CREATE TABLE community_posts(
 id INT AUTO_INCREMENT PRIMARY KEY,
 user_id INT NOT NULL, content TEXT, likes INT DEFAULT 0, created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
 FOREIGN KEY(user_id) REFERENCES users(id) ON DELETE CASCADE
);
CREATE TABLE community_comments(
 id INT AUTO_INCREMENT PRIMARY KEY,
 post_id INT NOT NULL, user_id INT NOT NULL, comment TEXT, created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
 FOREIGN KEY(post_id) REFERENCES community_posts(id) ON DELETE CASCADE,
 FOREIGN KEY(user_id) REFERENCES users(id) ON DELETE CASCADE
);

INSERT INTO users(full_name,username,email,password,role) VALUES
('Juan Dela Cruz','user','user@example.com',MD5('user123'),'user');
INSERT INTO members(user_id,phone,address,gender,birthday,height_cm,weight_kg,goal,level_points) VALUES
(1,'09123456789','Manila','Male','2002-05-01',170,70,'Muscle Gain',240);
INSERT INTO medical_histories(member_id,allergies,conditions,medications,notes) VALUES
(1,'None','None','None','Fit for light to moderate exercise.');
INSERT INTO subscription_plans(plan_name,duration_months,price,description) VALUES
('Monthly',1,999,'Basic monthly gym access'),('Quarterly',3,2699,'Three months with trainer consultation'),('Yearly',12,8999,'Full year access with premium benefits');
INSERT INTO payments(member_id,plan_id,amount,payment_date,due_date,status,invoice_no) VALUES
(1,1,999,CURDATE(),DATE_ADD(CURDATE(), INTERVAL 1 MONTH),'paid','INV-1001');
INSERT INTO classes(trainer_id,title,class_type,schedule_datetime,capacity,stream_link,description) VALUES
(NULL,'Morning HIIT Blast','HIIT',DATE_ADD(NOW(), INTERVAL 2 DAY),30,'https://www.youtube.com/embed/ml6cT4AZdqI','Fast fat-burning class for beginners.'),
(NULL,'Power Yoga Flow','Yoga',DATE_ADD(NOW(), INTERVAL 3 DAY),25,'https://www.youtube.com/embed/v7AYKMP6rOE','Flexibility and mindfulness workout.'),
(NULL,'Zumba Energy','Zumba',DATE_ADD(NOW(), INTERVAL 4 DAY),35,'https://www.youtube.com/embed/ZWk19OVon2k','Dance-based cardio class.');
INSERT INTO goals(member_id,title,target_value,current_value,unit,target_date) VALUES
(1,'Lose body fat',65,70,'kg',DATE_ADD(CURDATE(), INTERVAL 60 DAY)),(1,'Daily steps',10000,7200,'steps',CURDATE());
INSERT INTO activity_logs(member_id,log_date,steps,workout,calories_burned,weight_kg,notes) VALUES
(1,DATE_SUB(CURDATE(), INTERVAL 6 DAY),4500,'Walking',180,71,'Started routine'),(1,DATE_SUB(CURDATE(), INTERVAL 5 DAY),6200,'Cardio',260,70.8,'Good session'),(1,DATE_SUB(CURDATE(), INTERVAL 4 DAY),7300,'HIIT',350,70.5,'Tiring but good'),(1,DATE_SUB(CURDATE(), INTERVAL 3 DAY),8100,'Strength',400,70.3,'Improved'),(1,DATE_SUB(CURDATE(), INTERVAL 2 DAY),9200,'Jogging',430,70.1,'Great'),(1,DATE_SUB(CURDATE(), INTERVAL 1 DAY),10000,'Zumba',500,70,'Goal reached');
INSERT INTO health_records(member_id,record_date,systolic,diastolic,heart_rate,temperature,blood_sugar,oxygen_level,weight_kg,bmi,status,notes) VALUES
(1,CURDATE(),118,76,72,36.7,95,98,70,24.22,'Normal','Healthy vitals');
INSERT INTO recipes(name,goal,calories,protein,carbs,fats,ingredients,instructions) VALUES
('Chicken Veggie Bowl','Muscle Gain',550,45,55,14,'Chicken breast, rice, broccoli, carrots','Grill chicken, steam vegetables, serve with rice.'),
('Tuna Salad Wrap','Weight Loss',350,30,32,9,'Tuna, lettuce, whole wheat wrap','Mix and wrap ingredients.'),
('Oat Banana Smoothie','Maintenance',420,18,65,10,'Oats, banana, milk, peanut butter','Blend all ingredients.'),
('Egg Avocado Toast','Muscle Gain',480,24,38,23,'Eggs, avocado, wheat bread','Toast bread and top with eggs and avocado.');
INSERT INTO community_posts(user_id,content,likes) VALUES
(1,'Finished my first HIIT class today! Feeling motivated.',5),(1,'Remember: consistency beats intensity. Keep moving!',8);
