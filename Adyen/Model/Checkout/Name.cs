
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Adyen.Model.Checkout
{
    /// <summary>
    /// Name
    /// </summary>
    [DataContract]
    public partial class Name :  IEquatable<Name>, IValidatableObject
    {
        /// <summary>
        /// The gender. &gt;The following values are permitted: &#x60;MALE&#x60;, &#x60;FEMALE&#x60;, &#x60;UNKNOWN&#x60;.
        /// </summary>
        /// <value>The gender. &gt;The following values are permitted: &#x60;MALE&#x60;, &#x60;FEMALE&#x60;, &#x60;UNKNOWN&#x60;.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GenderEnum
        {
            
            /// <summary>
            /// Enum MALE for value: MALE
            /// </summary>
            [EnumMember(Value = "MALE")]
            MALE = 1,
            
            /// <summary>
            /// Enum FEMALE for value: FEMALE
            /// </summary>
            [EnumMember(Value = "FEMALE")]
            FEMALE = 2,
            
            /// <summary>
            /// Enum UNKNOWN for value: UNKNOWN
            /// </summary>
            [EnumMember(Value = "UNKNOWN")]
            UNKNOWN = 3
        }

        /// <summary>
        /// The gender. &gt;The following values are permitted: &#x60;MALE&#x60;, &#x60;FEMALE&#x60;, &#x60;UNKNOWN&#x60;.
        /// </summary>
        /// <value>The gender. &gt;The following values are permitted: &#x60;MALE&#x60;, &#x60;FEMALE&#x60;, &#x60;UNKNOWN&#x60;.</value>
        [DataMember(Name="gender", EmitDefaultValue=false)]
        public GenderEnum Gender { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Name" /> class.
        /// </summary>
        [JsonConstructor]
        protected Name() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Name" /> class.
        /// </summary>
        /// <param name="FirstName">The first name. (required).</param>
        /// <param name="Gender">The gender. &gt;The following values are permitted: &#x60;MALE&#x60;, &#x60;FEMALE&#x60;, &#x60;UNKNOWN&#x60;. (required).</param>
        /// <param name="Infix">The name&#39;s infix, if applicable. &gt;A maximum length of twenty (20) characters is imposed..</param>
        /// <param name="LastName">The last name. (required).</param>
        public Name(string FirstName = default(string), GenderEnum Gender = default(GenderEnum), string Infix = default(string), string LastName = default(string))
        {
            // to ensure "FirstName" is required (not null)
            if (FirstName == null)
            {
                throw new InvalidDataException("FirstName is a required property for Name and cannot be null");
            }
            else
            {
                this.FirstName = FirstName;
            }
            // to ensure "Gender" is required (not null)
            if (Gender == null)
            {
                throw new InvalidDataException("Gender is a required property for Name and cannot be null");
            }
            else
            {
                this.Gender = Gender;
            }
            // to ensure "LastName" is required (not null)
            if (LastName == null)
            {
                throw new InvalidDataException("LastName is a required property for Name and cannot be null");
            }
            else
            {
                this.LastName = LastName;
            }
            this.Infix = Infix;
        }
        
        /// <summary>
        /// The first name.
        /// </summary>
        /// <value>The first name.</value>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }


        /// <summary>
        /// The name&#39;s infix, if applicable. &gt;A maximum length of twenty (20) characters is imposed.
        /// </summary>
        /// <value>The name&#39;s infix, if applicable. &gt;A maximum length of twenty (20) characters is imposed.</value>
        [DataMember(Name="infix", EmitDefaultValue=false)]
        public string Infix { get; set; }

        /// <summary>
        /// The last name.
        /// </summary>
        /// <value>The last name.</value>
        [DataMember(Name="lastName", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Name {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  Infix: ").Append(Infix).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Name);
        }

        /// <summary>
        /// Returns true if Name instances are equal
        /// </summary>
        /// <param name="input">Instance of Name to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Name input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.Gender == input.Gender ||
                    (this.Gender != null &&
                    this.Gender.Equals(input.Gender))
                ) && 
                (
                    this.Infix == input.Infix ||
                    (this.Infix != null &&
                    this.Infix.Equals(input.Infix))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.Gender != null)
                    hashCode = hashCode * 59 + this.Gender.GetHashCode();
                if (this.Infix != null)
                    hashCode = hashCode * 59 + this.Infix.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Gender (string) maxLength
            if(this.Gender != null && this.Gender.ToString().Length > 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Gender, length must be less than 1.", new [] { "Gender" });
            }

            // Gender (string) minLength
            if(this.Gender != null && this.Gender.ToString().Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Gender, length must be greater than 1.", new [] { "Gender" });
            }

            yield break;
        }
    }

}
