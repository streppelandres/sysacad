# Migrations:
- Create a migration: `add-migration FirstMigration -o Migrations`
- Update database: `update-database`

# TODO:
- [ ] Auditory data must be a in a separated table
- [ ] Better reponse in validations error messages
- [ ] Some exception/error handler for invalid URL
- [ ] Creates JWT
- [ ] Add roles with JWT
- [ ] Try to investigate if is possible to create something like secrets for the config
- [ ] Make all saved data in db in Capitalize
- [ ] Email service
- [ ] More and betters DTO's, maybe use separated "Response" for each Query/Command operation

## Schedule
- [ ] Change `string` type to the dates (`StartTime` and `EndTime`) of `Schedule`
- [ ] Evolve `DayOfWeek`, add some Enum or something better
- [ ] Create correct Date validations