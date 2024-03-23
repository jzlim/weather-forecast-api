use weatherappdb
GO

insert into Cities 
values
((select Id from States where name = 'Pahang'), 'Kuantan', 3.763386, 103.220184),
((select Id from States where name = 'Johor'), 'Johor Bahru', 1.4799, 103.7643),
((select Id from States where name = 'Johor'), 'Iskandar Puteri', 1.4200, 103.6305),
((select Id from States where name = 'Kedah'), 'Alor Setar', 6.124800, 100.367821),
((select Id from States where name = 'Kelantan'), 'Kota Bharu', 6.139872, 102.242203),
((select Id from States where name = 'Melaka'), 'Malacca', 2.200844, 102.240143),
((select Id from States where name = 'Negeri Sembilan'), 'Seremban', 2.7259, 101.9378),
((select Id from States where name = 'Perak'), 'Ipoh', 4.597479,	101.090103),
((select Id from States where name = 'Perlis'), 'Kangar', 6.4406, 100.1984),
((select Id from States where name = 'Penang'), 'George Town', 5.425300, 100.312386),
((select Id from States where name = 'Sabah'), 'Kota Kinabalu', 5.9844, 116.0773),
((select Id from States where name = 'Sarawak'), 'Kuching', 1.553110, 110.345032),
((select Id from States where name = 'Selangor'), 'hah Alam', 3.0733, 101.5185),
((select Id from States where name = 'Selangor'), 'Petaling Jaya', 3.127887, 101.594490),
((select Id from States where name = 'Selangor'), 'Subang Jaya', 3.0567, 101.5851),
((select Id from States where name = 'Selangor'), 'Klang', 3.044917, 101.445564),
((select Id from States where name = 'Terengganu'), 'Kuala Terengganu', 5.3283, 103.1412),
((select Id from States where name = 'Federal Territory'), 'Kuala Lumpur', 3.140853, 101.693207),
((select Id from States where name = 'Federal Territory'), 'Putrajaya', 2.9264, 101.6964)
