using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace DarkMatter.Stimtest.Migrations.EntityBuilders
{
    public class StimtestEntityBuilder : AuditableBaseEntityBuilder<StimtestEntityBuilder>
    {
        private const string _entityTableName = "DarkMatterStimtest";
        private readonly PrimaryKey<StimtestEntityBuilder> _primaryKey = new("PK_DarkMatterStimtest", x => x.StimtestId);
        private readonly ForeignKey<StimtestEntityBuilder> _moduleForeignKey = new("FK_DarkMatterStimtest_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public StimtestEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override StimtestEntityBuilder BuildTable(ColumnsBuilder table)
        {
            StimtestId = AddAutoIncrementColumn(table,"StimtestId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> StimtestId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
