﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Business_Platform.Model
{
    public class ClothingProduct
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Range(0, float.MaxValue)]
        public float Price { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        [DisplayName("Image")]
        [StringLength(150)]
        public string? ImageFileName { get; set; }

        public int ClothingTypeId { get; set; }

        [ForeignKey("ClothingTypeId")]
        public ClothingType? ClothingType { get; set; }

        public int AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; } // Ürün Satıcısı

        public byte StateId { get; set; }

        [ForeignKey("StateId")]
        public State? State { get; set; }

        public List<ProductComment>? ProductComments { get; set; }



    }
}
