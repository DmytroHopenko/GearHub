EF = dotnet EF
PROJECTS = -p src/GearHub.Infrastructure -s src/GearHub.Api

.PHONY: migration db-update

migration:
	$(EF) migrations add "$(name)" $(PROJECTS) -o Persistence/Migrations -- --environment Development

db-update:
	$(EF) database update $(PROJECTS) -- --environment Development