CREATE SEQUENCE task_seq
    START WITH      1
    INCREMENT BY    1
    NOCYCLE;
    
    
CREATE TABLE task (
    id            NUMBER(8)       DEFAULT task.seq.NEXTVAL    PRIMARY KEY,
    title         VARCHAR2(20)    NOT NULL,
    description   VARCHAR2(100)   NOT NULL,
    status        VARCHAR2(20)    NOT NULL,
    developer     VARCHAR2(20)    NOT NULL,
    date_created  DATE            DEFAULT SYSDATE    NOT NULL,
    date_updated  DATE
);

SELECT * FROM task;