# Migrations:
- Create a migration: `add-migration FirstMigration -o Migrations`
- Update database: `update-database`

# TODO:
- [ ] Auditory data must be a in a separated table

## Schedule
- [ ] Change `string` type to the dates (`StartTime` and `EndTime`) of `Schedule`
- [ ] Evolve `DayOfWeek`, add some Enum or something better
- [ ] Create correct Date validations