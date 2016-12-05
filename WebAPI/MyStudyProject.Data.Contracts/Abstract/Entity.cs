using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using MyStudyProject.Data.Contracts.Interface;

namespace MyStudyProject.Data.Contracts.Abstract
{
    /// <summary>
    ///   Base class for entitities.
    /// </summary>
    [DebuggerDisplay("Id = {Id}")]
    public abstract class Entity : IEntity
    {
        /// <summary>
        ///   Gets or sets object id.
        /// </summary>
        [Key]
        [Display(Name = "Id")]
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        ///   Gets a value indicating whether entity is newly created.
        /// </summary>
        public bool IsNew => Id <= 0;

        /// <summary>
        ///   Gets a value indicating whether entity is deleted
        /// </summary>
        public bool IsDeleted
        {
            get;
            set;
        }

        /// <summary>
        ///   Overrides base equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            if (obj == null || entity == null || GetType() != entity.GetType())
            {
                return false;
            }

            return !IsNew && entity.Id.Equals(Id);
        }

        private int? hashCode;
        /// <summary>
        ///   Calculates hash code of the object.
        /// </summary>
        /// <returns>Returns hash code of the object.</returns>
        public override int GetHashCode()
        {
            if (hashCode == null)
            {
                hashCode = (int)(37 * Id) + 17;
            }

            return hashCode.Value;
        }
    }
}
