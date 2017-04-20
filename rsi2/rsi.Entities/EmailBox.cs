using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rsi.Entities.AdvertiserDetails;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace rsi.Entities
{
    public class EmailBox : Auxiliar
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        public string Client_Host { get; set; } //por exemplo: client.Host = "smtp.gmail.com";
        public string Email_Sender { get; set; }
        public string Email_To { get; set; }
        public string Email_To2 { get; set; }
        public string Email_Cc { get; set; } // cópia para
        public string Email_Bcc { get; set; } // cópia oculta
        public string Email_Subject { get; set; }
        public string Email_Body { get; set; }

        public string Email_Sender_Name { get; set; }
        public string Email_Sender_Tel { get; set; }
        public string Email_To_Name { get; set; }
        public string Email_To_Tel { get; set; }

        public int AdvertiserId { get; set; }
        public int OriginalMessageId { get; set; }

        public MailPriority Email_Priority { get; set; } // High, Low, Normal - enum da classe MailMessage (using System.Net.Mail)
        public readingStatus ReadingStatus { get; set; } // notSet, read, Unread, archived, trash, draft, sent
        public receiver Receiver { get; set; } // notSet, toAdvertiser, toAdvertiserBudgetRequest, toSiteOwner, toSiteOwnerSideWidget, toVisitorFriend
        //public contactType ContactType { get; set; }
    }   
}