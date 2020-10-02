namespace Backend
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public long Phone1 { get; set; }
        public long Phone2 { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public int[] AdIds { get; set; }
    }
}
