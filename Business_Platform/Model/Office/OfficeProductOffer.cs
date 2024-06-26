﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Business_Platform.Model.Identity;

namespace Business_Platform.Model.Office
{
    public class OfficeProductOffer
    {
        public enum OfferStatus
        {
            [Display(Name = "Beklemede")]
            Pending,
            [Display(Name = "Kabul Edildi")]
            Accepted,
            [Display(Name = "Reddedildi")]
            Rejected  
        }


        public int Id { get; set; }
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }

        public int? OfficeCompanyId { get; set; }

        [ForeignKey("OfficeCompanyId")]
        public OfficeCompany? OfficeCompany { get; set; }

        public int? OfficeCompanyBranchId { get; set; }

        [ForeignKey("OfficeCompanyBranchId")]
        public OfficeCompanyBranch? OfficeCompanyBranch { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public OfficeProdBranchProduct? OfficeProdBranchProduct { get; set; }

        public OfferStatus Status { get; set; } = OfferStatus.Pending;  // Başlangıç değeri pending(beklemede) olsun
    }
}
