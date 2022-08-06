using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace DarkMatter.Stimulsoft.Migrations.EntityBuilders
{
    public class StimulsoftEntityBuilder : AuditableBaseEntityBuilder<StimulsoftEntityBuilder>
    {
        private const string _entityTableName = "DarkMatterStimulsoft";
        private readonly PrimaryKey<StimulsoftEntityBuilder> _primaryKey = new("PK_DarkMatterStimulsoft", x => x.StimulsoftId);
        private readonly ForeignKey<StimulsoftEntityBuilder> _moduleForeignKey = new("FK_DarkMatterStimulsoft_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public StimulsoftEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override StimulsoftEntityBuilder BuildTable(ColumnsBuilder table)
        {
            StimulsoftId = AddAutoIncrementColumn(table,"StimulsoftId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> StimulsoftId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
