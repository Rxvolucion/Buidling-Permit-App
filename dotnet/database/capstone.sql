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
    employee_id int IDENTITY(4001,1) NOT NULL,
    user_id INT NOT NULL,
    employee_type varchar(50) NOT NULL, --inspector or admin
    CONSTRAINT PK_employee_id PRIMARY KEY (employee_id),
    CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES users(user_id) -- Add REFERENCES clause for foreign key
);

CREATE TABLE customer (
    customer_id int IDENTITY(1001,1) NOT NULL,
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
	customer_details varchar(200),
	CONSTRAINT CK_permit_status CHECK (permit_status IN ('Pending', 'Approved', 'Rejected')),
    CONSTRAINT PK_permit_id PRIMARY KEY (permit_id),
    CONSTRAINT FK_customer_id FOREIGN KEY (customer_id) REFERENCES customer(customer_id) -- Add REFERENCES clause for foreign key
);

CREATE TABLE inspection_type (
	inspection_type_id int IDENTITY (5001,1) NOT NULL,
	inspections_type varchar(50) NOT NULL,
	CONSTRAINT PK_inspection_type_id PRIMARY KEY (inspection_type_id),
	CONSTRAINT CK_inspection_type CHECK (inspections_type IN ('Plumbing', 'Electrical', 'Structural', 'HVAC'))

);

CREATE TABLE inspection_status_type (
	inspection_status_type_id int IDENTITY (6001,1) NOT NULL,
	inspection_type varchar(50) NOT NULL,
	CONSTRAINT PK_inspection_status_type_id PRIMARY KEY (inspection_status_type_id),
	CONSTRAINT CK_type CHECK (inspection_type IN ('Pass', 'Fail', 'Pending'))
);

CREATE TABLE inspections (
    inspection_id int IDENTITY(3001,1) NOT NULL,
	inspection_status_type_id INT,
	permit_id INT NOT NULL,
    inspection_type_id int NOT NULL,
    --address varchar(125),
    date_variable datetime,
	notes varchar(200),
    CONSTRAINT PK_inspection_id PRIMARY KEY (inspection_id),
    CONSTRAINT FK_permit_id FOREIGN KEY (permit_id) REFERENCES permit(permit_id),
	CONSTRAINT FK_inspection_status_type_id FOREIGN KEY (inspection_status_type_id) REFERENCES inspection_status_type(inspection_status_type_id),
    CONSTRAINT FK_inspection_type_id FOREIGN KEY (inspection_type_id) REFERENCES inspection_type(inspection_type_id)
);

CREATE TABLE inspection_files (
    inspection_files_id int IDENTITY(7001,1) NOT NULL,
	inspection_URLs varchar(200),
    CONSTRAINT PK_inspection_files_id PRIMARY KEY (inspection_files_id)	
);



INSERT INTO inspection_type (inspections_type) VALUES ('Plumbing')
INSERT INTO inspection_type (inspections_type) VALUES ('Electrical')
INSERT INTO inspection_type (inspections_type) VALUES ('Structural')
INSERT INTO inspection_type (inspections_type) VALUES ('HVAC')


-- populate default data
-- password for these is "password"
INSERT INTO inspection_status_type (inspection_type) VALUES ('Pending')
INSERT INTO inspection_status_type (inspection_type) VALUES ('Pass')
INSERT INTO inspection_status_type (inspection_type) VALUES ('Fail')

INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user1','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata1@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user2','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata2@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user3','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata3@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user4','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata4@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user5','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata5@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user6','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata6@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user7','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata7@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user8','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata8@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user9','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata9@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user10','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata11@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user11','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata12@te.com',1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('user12','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=', 'user',0 , 'testdata13@te.com',0);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('admin1','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'admin', 1, 'employeeemail1@company.com', 1);
INSERT INTO users (username, password_hash, salt, user_role, employee, email, active) VALUES ('admin2','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=', 'admin', 1,'employeeemail2@company.com', 1);

INSERT INTO employee (user_id, employee_type) VALUES (4, 'admin');
INSERT INTO employee (user_id, employee_type) VALUES ( 5, 'admin');

INSERT INTO customer (user_id, contractor, address) VALUES (1, 1, '31 Spooner St.');
INSERT INTO customer (user_id, contractor, address) VALUES (2, 1, '5001 Real St..');
INSERT INTO customer (user_id, contractor, address) VALUES (3, 1, '123 Main St.');
INSERT INTO customer (user_id, contractor, address) VALUES (4, 1, '456 Oak Rd.');
INSERT INTO customer (user_id, contractor, address) VALUES (5, 0, '789 Elm St.');
INSERT INTO customer (user_id, contractor, address) VALUES (6, 1, '321 Pine Ln.');
INSERT INTO customer (user_id, contractor, address) VALUES (7, 1, '654 Maple Ave.');
INSERT INTO customer (user_id, contractor, address) VALUES (8, 0, '987 Oak St.');
INSERT INTO customer (user_id, contractor, address) VALUES (9, 0, '159 Birch Rd.');
INSERT INTO customer (user_id, contractor, address) VALUES (11, 1, '753 Willow Ln.');
INSERT INTO customer (user_id, contractor, address) VALUES (12, 1, '369 Cedar St.');
INSERT INTO customer (user_id, contractor, address) VALUES (13, 1, '852 Maple Rd.');



INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1001, '31 Spooner St.', 'house', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1001, '4621 Grangerwood Ave.', 'house', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1002, '5001 Real St.', 'building', 1, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1003, '123 Main St.', 'New Garage', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1004, '456 Oak Rd.', 'New Garage', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1005, '789 Elm St.', 'Building Addition', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (0, 1006, '321 Pine Ln.', 'Building Addition', 1, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1007, '654 Maple Ave.', 'Electrical Work', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1008, '987 Oak St.', 'Electrical Work', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1009, '159 Birch Rd.', 'HVAC Work', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1010, '753 Willow Ln.', 'HVAC Work', 1, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (0, 1011, '369 Cedar St.', 'Interior Alterations', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1012, '852 Maple Rd.', 'Interior Alterations', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1004, '456 Oak Rd.', 'Electrical Work', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1005, '789 Elm St.', 'Electrical Work', 0, 'Rejected', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1006, '321 Pine Ln.', 'Electrical Work', 1, 'Rejected', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (0, 1007, '654 Maple Ave.', 'Building Addition', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1008, '987 Oak St.', 'New Garage', 0, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1009, '159 Birch Rd.', 'New Garage', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1010, '753 Willow Ln.', 'Electrical Work', 1, 'Approved', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1011, '369 Cedar St.', 'Electrical Work', 0, 'Pending', 'none');
INSERT INTO permit (active, customer_id, permit_address, permit_type, commercial, permit_status, customer_details) VALUES (1, 1012, '852 Maple Rd.', 'HVAC Work', 0, 'Pending', 'none');

INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6001, 2001, 5001, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6002, 2001, 5002, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6003, 2002, 5003, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6003, 2002, 5003, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6001, 2001, 5001, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6001, 2001, 5001, '2024-04-10T12:00:00', null)
INSERT INTO inspections (inspection_status_type_id, permit_id, inspection_type_id, date_variable, notes) VALUES (6001, 2001, 5001, '2024-04-10T12:00:00', null)




GO

