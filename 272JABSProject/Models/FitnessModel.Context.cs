﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _272JABSProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FitnessEntities : DbContext
    {
        public FitnessEntities()
            : base("name=FitnessEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AmountEaten> AmountEatens { get; set; }
        public virtual DbSet<CondtionType> CondtionTypes { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<ConversationReply> ConversationReplies { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<Excercis> Excercises { get; set; }
        public virtual DbSet<ExcercisesDone> ExcercisesDones { get; set; }
        public virtual DbSet<ReccomendedDiet> ReccomendedDiets { get; set; }
        public virtual DbSet<ReccomendedExcercise> ReccomendedExcercises { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserCondition> UserConditions { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}
