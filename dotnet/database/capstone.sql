USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
    user_id int IDENTITY(1,1) NOT NULL,
    username varchar(50) NOT NULL,
    password_hash varchar(200) NOT NULL,
    salt varchar(200) NOT NULL,
    user_type BIT NOT NULL,  --1 indicates employee; 0 is customer.
    CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE employee (
    employee_id int IDENTITY(1001,1) NOT NULL,
    username varchar(50) NOT NULL,
    user_id INT NOT NULL,
    employee_type varchar(50) NOT NULL, --inspector or admin
    CONSTRAINT PK_employee_id PRIMARY KEY (employee_id),
    CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES users(user_id) -- Add REFERENCES clause for foreign key
);



-- populate default data
-- password for these is "password"
INSERT INTO users (username, password_hash, salt, user_type) VALUES ('John Kevin Patrick','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 0);
INSERT INTO users (username, password_hash, salt, user_type) VALUES ('Dio Moe Jeff','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 1);

INSERT INTO employee (username, user_id, employee_type) VALUES ('Dio Moe Jeff', 2, 'inspector');

--INSERT INTO employee (username, user_id, employee_type) VALUES ('user', 1, 'inspector')
GO
