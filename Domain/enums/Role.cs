using Ardalis.SmartEnum;

namespace Domain.enums
{
    public sealed class Role : SmartEnum<Role>
    {
        private Role(string name, int value, List<Permision> permisions) : base(name,value)
        {
            Permisions = permisions;

        }

        public static readonly Role Owner = new(nameof(Owner), 1, new()
        {


             Permision.CreateNote,
             Permision. EditNote,
             Permision. DeleteNote,
             Permision.ReadNotes,

              Permision.CreateCategory,
              Permision.EditCategory,
              Permision.DeleteCategory,
              Permision.ReadCategories,

            Permision.AddMember,
            Permision.DeleteMember,
            Permision.EditMemberRole,
            Permision.ReadMembers,

        });

        public static readonly Role Editor = new(nameof(Editor), 2, new()
        {
            Permision.CreateNote,
             Permision. EditNote,
             Permision. DeleteNote,
             Permision.ReadNotes,
              Permision.CreateCategory,
              Permision.EditCategory,
              Permision.DeleteCategory,
              Permision.ReadCategories,

        });

        public static readonly Role Viewer = new(nameof(Viewer), 3, new()
        {

                Permision.ReadCategories,
                Permision.ReadNotes,

        });

        public List<Permision> Permisions { get; set; }

    }
}
