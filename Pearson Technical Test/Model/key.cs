using CsvHelper.Configuration.Attributes;

namespace Pearson_Technical_Test.Model
{
    public class key
    {
        public string student_id { get; set; }


        public string name { get; set; }


        public string subject { get; set; }

        public override bool Equals(object obj)
        {
            //see if the obj type like key type or not
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            key other = (key)obj;

            return student_id == other.student_id &&
                   name == other.name &&
                   subject == other.subject;
        }

        public override int GetHashCode()
        {
            return student_id.GetHashCode() ^ name.GetHashCode() ^ subject.GetHashCode();
        }
    }
}
