CREATE TABLE pb.Beer (
    BeerId INT NOT NULL,
    Name CHARACTER VARYING,
    BrandId INT,
    PRIMARY KEY (BeerId),
    FOREIGN KEY (BrandId) REFERENCES pb.Brand(BrandId)
);