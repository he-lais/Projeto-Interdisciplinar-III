using System;

namespace DocJur.Api.App.Models
{
    /// <summary>
    /// Common representation for all entities.
    /// </summary>
    public abstract class AppModel
    {
        /// <summary>
        /// Entity Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of last change.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected AppModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
