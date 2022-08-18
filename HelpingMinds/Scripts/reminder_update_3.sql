use HelpingMinds

alter table Reminder
add actualRepeat bit,
userId int,
foreign key(userId) references Users(userId)
