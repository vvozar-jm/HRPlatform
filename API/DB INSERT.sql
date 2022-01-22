INSERT INTO Candidates (Id, Name, DateOfBirth, ContactNumber, Email)
VALUES (1, 'Marko Markovic', '05/15/2002', '123-456', 'markom@gmail.com');

INSERT INTO Candidates (Id, Name, DateOfBirth, ContactNumber, Email)
VALUES (2, 'Petar Petrovic', '09/17/1992', '111-222', 'petarp@gmail.com');

INSERT INTO Candidates (Id, Name, DateOfBirth, ContactNumber, Email)
VALUES (3, 'Janko Jankovic', '03/22/2005', '654-321', 'jankoj@gmail.com');

INSERT INTO Skills (Id, Name)
VALUES (1, 'Java programming');

INSERT INTO Skills (Id, Name)
VALUES (2, 'C# Programming');

INSERT INTO Skills (Id, Name)
VALUES (3, 'Database Design');

INSERT INTO Skills (Id, Name)
VALUES (4, 'English Language');

INSERT INTO Skills (Id, Name)
VALUES (5, 'Russian Language');

INSERT INTO Skills (Id, Name)
VALUES (6, 'German Language');

INSERT INTO CandidateSkill (CandidatesId, SkillsId)
VALUES (1, 1);

INSERT INTO CandidateSkill (CandidatesId, SkillsId)
VALUES (2, 2);

INSERT INTO CandidateSkill (CandidatesId, SkillsId)
VALUES (3, 3);