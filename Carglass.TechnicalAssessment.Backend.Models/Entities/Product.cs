﻿namespace Carglass.TechnicalAssessment.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int ProductType { get; set; }
    public long NumTerminal { get; set; }
    public DateTime SoldAt { get; set; }
}