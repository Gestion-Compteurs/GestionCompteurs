### Important
- Manage OnDelete for InstanceCompteurs : do not delete related data, no cascade
- Add validators of foreign keys in models and CreateDtos, for min values
- Ensure Instances retrieved include or do not include their dependant models(Compteurs-Cadran & InstanceCompteurs-InstanceCadrans)
- Specify Models that can have update & delete and model that cannot
- Reset EF database
- Remove include from non details retrievements
- Rewrite InstanceCompteur Creation to be less dependant from route ?
- Move to MsSql Server, end of project