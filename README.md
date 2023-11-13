# sysacad

# Structure
- `/docs`:
    Documentation folder
- `/src`:
    Source code folder

# App layers
- Application:
    Bussines logic
	Knows: Entities and Persistence
- Persistence:
    Database logic
    Knows: Entities
- Entities:
    All entities
    Knows: None
vPresentation:
    UI Layer, Windows Forms in this case
    Knows: Applications

# Migrations commands
In package manager console:
- `add-migration MIGRATION_NAME -o Migrations`, creates migrations files
- `Update-Database`, updates database with the migrations files
