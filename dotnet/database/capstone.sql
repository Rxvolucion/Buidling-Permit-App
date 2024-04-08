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
	user_role varchar(50) NOT NULL,
    employee BIT NOT NULL,  --0 indicates employee; 1 is customer.
	email varchar(75) UNIQUE NOT NULL,
	active BIT NOT NULL, --0 indicates inactive, 1 is active (instead of deleting acct, set as inactive)
    CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE employee (
    employee_id int IDENTITY(1001,1) NOT NULL,
    user_id INT NOT NULL,
    employee_type varchar(50) NOT NULL, --inspector or admin
    CONSTRAINT PK_employee_id PRIMARY KEY (employee_id),
    CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES users(user_id) -- Add REFERENCES clause for foreign key
);

CREATE TABLE customer (
    customer_id int IDENTITY(1001,1) NOT NULL,
    username varchar(50) NOT NULL,
    user_id INT NOT NULL,
	contractor BIT NOT NULL, --0 indicates not contractor; 1 is contractor.
	address varchar(125) NOT NULL,
    CONSTRAINT PK_customer_id PRIMARY KEY (customer_id),
    CONSTRAINT FK_user_id_ FOREIGN KEY (user_id) REFERENCES users(user_id) -- Add REFERENCES clause for foreign key
);

CREATE TABLE permit (
    permit_id int IDENTITY(2001,1) NOT NULL, 
	active BIT NOT NULL, --0 indicates inactive, 1 is active (instead of deleting acct, set as inactive)
	customer_id int NOT NULL,
	permit_address varchar(125) NOT NULL,
    permit_type varchar(50) NOT NULL,
    commercial BIT NOT NULL, --0 indicates residential; 1 is commercial.
	permit_status varchar(50) NOT NULL,
	CONSTRAINT CK_permit_status CHECK (permit_status IN ('Pending', 'Approved', 'Rejected')),
    CONSTRAINT PK_permit_id PRIMARY KEY (permit_id),
    CONSTRAINT FK_customer_id FOREIGN KEY (customer_id) REFERENCES customer(customer_id) -- Add REFERENCES clause for foreign key
);

-- populate default data
-- password for these is "password"
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user1','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('admin1','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'admin', 1, 'employeeemail1@company.com', 1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('admin2','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'admin', 1,'employeeemail2@company.com', 1);

INSERT INTO employee (user_id, employee_type) VALUES (2, 'admin');
INSERT INTO employee (user_id, employee_type) VALUES ( 3, 'admin');

INSERT INTO customer (username, user_id, contractor, address) VALUES ('user1', 1, 1, 'something st.');

GO

