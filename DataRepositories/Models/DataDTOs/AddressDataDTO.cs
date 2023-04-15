﻿namespace InSharpAssessment.DataRepositories.Models.DTOs
{
    internal class AddressDataDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}