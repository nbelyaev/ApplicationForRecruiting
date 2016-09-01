Database is created Code First using models from the runtime, currently only way to change database 
is by removing all the tables from database and deploying the runtime to Azure. It might be possible 
to use migrations for database changes so that there’s no need to lose database data, more on this here 
http://robertgreiner.com/2012/05/using-entity-framework-database-migrations-to-update-a-remote-database/ .  

Currently lookup tables (UserRole, CandidatePosition, CandidateSkill, PositionSkill, InterviewAssign, 
CandidateStatus) have Id fields rather than composite keys, so there is a chance that there might be repeats. 
It is recommended that in the future tables that should have unique relationships get rid of Id fields in 
favor of composite keys in order to avoid errors.

Use this as a reference to set up relationships in the database, as currently related data is not being loaded
https://azure.microsoft.com/en-us/documentation/articles/mobile-services-dotnet-backend-use-existing-sql-database/
