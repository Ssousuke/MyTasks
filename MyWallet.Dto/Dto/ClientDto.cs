namespace MyWallet.Dto.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public bool IsActive { get; set; }
        public List<ProjectDto> Projects { get; set; }

    }
}
