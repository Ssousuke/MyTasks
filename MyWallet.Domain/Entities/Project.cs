﻿namespace MyWallet.Domain.Entities
{
    public sealed class Project
    {
        public Guid Id { get; private set; }
        public string ProjectName { get; private set; }
        public string ProjectDescription { get; private set; }
        public Auxiliar.Enum.ProjectStep ProjectStep { get; private set; }
        public ICollection<Client> Clients { get; private set; }
    }
}
