using NUnit.Framework;
using System.Text;
using System.Globalization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using var httpClient = new HttpClient();

namespace DataPreprocessing.Model
{
    public class DataPreprocessingModel {
         List<DataPreprocessing> Searchdatapreprocessing(List<DataPreprocessing> DataPreprocessing)
        {
            var DataPreprocessing = new List<DataPreprocessing>();
            string DataPreprocessingSql = @"SELECT * FROM DataPreprocessing 
                WHERE label LIKE DataPreprocessing.label
                OR notes LIKE DataPreprocessing.notes
                OR processing_time LIKE DataPreprocessing.processing_time
                AND tokenized_text LIKE DataPreprocessing.tokenized_text
                AND format LIKE DataPreprocessing.format
                OR data_id LIKE DataPreprocessing.data_id
                AND cleaned_text LIKE DataPreprocessing.cleaned_text
                OR validation_result LIKE DataPreprocessing.validation_result
                AND status LIKE DataPreprocessing.status
                OR raw_text LIKE DataPreprocessing.raw_text
                OR source LIKE DataPreprocessing.source";
            var DataPreprocessingParames = new SqlDataPreprocessing[]
            {
                new SqlDataPreprocessing("@label",DataPreprocessing.label),
                new SqlDataPreprocessing("@notes",DataPreprocessing.notes),
                new SqlDataPreprocessing("@processing_time",DataPreprocessing.processing_time),
                new SqlDataPreprocessing("@tokenized_text",DataPreprocessing.tokenized_text),
                new SqlDataPreprocessing("@format",DataPreprocessing.format),
                new SqlDataPreprocessing("@data_id",DataPreprocessing.data_id),
                new SqlDataPreprocessing("@cleaned_text",DataPreprocessing.cleaned_text),
                new SqlDataPreprocessing("@validation_result",DataPreprocessing.validation_result),
                new SqlDataPreprocessing("@status",DataPreprocessing.status),
                new SqlDataPreprocessing("@raw_text",DataPreprocessing.raw_text),
                new SqlDataPreprocessing("@source",DataPreprocessing.source),
            };
            var DataPreprocessingdt = DatabaseHelper.ExecuteDataTable(DataPreprocessingSql, DataPreprocessingParames);
            foreach (DataRow DataPreprocessingrow in DataPreprocessingdt.Rows)
            {
                DataPreprocessingAdd(new DataPreprocessing
                {
                    label = Convert.ToDecimal(DataPreprocessingrow["label"]),
                    notes = Convert.ToInt32(DataPreprocessingrow["notes"]),
                    processing_time = Convert.ToDateTime(DataPreprocessingrow["processing_time"]),
                    tokenized_text = DataPreprocessingrow["tokenized_text"].ToString(),
                    format = DataPreprocessingrow["format"].ToString(),
                    data_id = Convert.ToDateTime(DataPreprocessingrow["data_id"]),
                    cleaned_text = Convert.ToInt32(DataPreprocessingrow["cleaned_text"]),
                    validation_result = Convert.ToInt32(DataPreprocessingrow["validation_result"]),
                    status = DataPreprocessingrow["status"].ToString(),
                    raw_text = Convert.ToDecimal(DataPreprocessingrow["raw_text"]),
                    source = Convert.ToDateTime(DataPreprocessingrow["source"]),
                });
            }
            return DataPreprocessing
        }

        public List<DataPreprocessing> account_datapreprocessing_store(int DataPreprocessingId)
        {
            string DataPreprocessingSql = "DELETE FROM DataPreprocessing WHERE DataPreprocessingId = @DataPreprocessingId";
            var DataPreprocessingParam = new SqlDataPreprocessing[]
            {
                new DataPreprocessingSql("@DataPreprocessingId",DataPreprocessingId)
            }
            return DatabaseHelper.ExecuteNonQuery(DataPreprocessingSql, DataPreprocessingParam) > 0;
        }

        /* 新增数据预处理
        label  double  标注标签
        notes  timestamp  备注
        processing_time  varchar  预处理时间
        tokenized_text  varchar  分词结果
        format  double  数据格式
        data_id  varchar  数据ID
        cleaned_text  datetime  清洗后文本
        validation_result  varchar  校验结果
        status  varchar  处理状态
        raw_text  bigint  原始文本
        source  int  数据来源
        */

         List<DataPreprocessing> datapreprocessingInsert(DataPreprocessing datapreprocessing)
        {
            string DataPreprocessingSql = @"INSERT INTO DataPreprocessing
                (label, notes, processing_time, tokenized_text, format, data_id, cleaned_text, validation_result, status, raw_text, source)
                VALUES 
                (@label, @notes, @processing_time, @tokenized_text, @format, @data_id, @cleaned_text, @validation_result, @status, @raw_text, @source)
                SELECT SCOPE_IDENTITY();";
            var DataPreprocessingParames = new SqlDataPreprocessing[]
            {
                new SqlDataPreprocessing("@label",DataPreprocessing.label),
                new SqlDataPreprocessing("@notes",DataPreprocessing.notes),
                new SqlDataPreprocessing("@processing_time",DataPreprocessing.processing_time),
                new SqlDataPreprocessing("@tokenized_text",DataPreprocessing.tokenized_text),
                new SqlDataPreprocessing("@format",DataPreprocessing.format),
                new SqlDataPreprocessing("@data_id",DataPreprocessing.data_id),
                new SqlDataPreprocessing("@cleaned_text",DataPreprocessing.cleaned_text),
                new SqlDataPreprocessing("@validation_result",DataPreprocessing.validation_result),
                new SqlDataPreprocessing("@status",DataPreprocessing.status),
                new SqlDataPreprocessing("@raw_text",DataPreprocessing.raw_text),
                new SqlDataPreprocessing("@source",DataPreprocessing.source),
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(DataPreprocessingSql, DataPreprocessingParames));
        }

        protected List<DataPreprocessing> ObtaindatapreprocessingEntity(int DataPreprocessingId)
        {
            string DataPreprocessingSql = "SELECT * FROM DataPreprocessing WHERE DataPreprocessingId = @DataPreprocessingId";
            var DataPreprocessingParam = new SqlDataPreprocessing[]
            {
                new DataPreprocessingSql("@DataPreprocessingId",DataPreprocessingId)
            }
            var DataPreprocessingRes = DatabaseHelper.ExecuteDataTable(DataPreprocessingSql, DataPreprocessingParam);
            if(DataPreprocessingRes.Rows.Count == 0) return null;
            var DataPreprocessingrow = DataPreprocessingRes.Rows[0];
            return new DataPreprocessing
            {
                label = Convert.ToInt32(DataPreprocessingrow["label"]),
                notes = Convert.ToDateTime(DataPreprocessingrow["notes"]),
                processing_time = DataPreprocessingrow["processing_time"].ToString(),
                tokenized_text = Convert.ToDateTime(DataPreprocessingrow["tokenized_text"]),
                format = DataPreprocessingrow["format"].ToString(),
                data_id = Convert.ToInt32(DataPreprocessingrow["data_id"]),
                cleaned_text = DataPreprocessingrow["cleaned_text"].ToString(),
                validation_result = DataPreprocessingrow["validation_result"].ToString(),
                status = DataPreprocessingrow["status"].ToString(),
                raw_text = DataPreprocessingrow["raw_text"].ToString(),
                source = Convert.ToInt32(DataPreprocessingrow["source"]),
            }
        }

        /* 新增数据预处理
        label  double  标注标签
        notes  timestamp  备注
        processing_time  varchar  预处理时间
        tokenized_text  varchar  分词结果
        format  double  数据格式
        data_id  varchar  数据ID
        cleaned_text  datetime  清洗后文本
        validation_result  varchar  校验结果
        status  varchar  处理状态
        raw_text  bigint  原始文本
        source  int  数据来源
        */

        public bool edit_datapreprocessing_info(DataPreprocessing datapreprocessing)
        {
            string DataPreprocessingSql = @"UPDATE  DataPreprocessing SET 
                label = @label,
                notes = @notes,
                processing_time = @processing_time,
                tokenized_text = @tokenized_text,
                format = @format,
                data_id = @data_id,
                cleaned_text = @cleaned_text,
                validation_result = @validation_result,
                status = @status,
                raw_text = @raw_text,
                source = @source,
                WHERE notes = @notes";
            var DataPreprocessingParames = new SqlDataPreprocessing[]
            {
                new SqlDataPreprocessing("@label",DataPreprocessing.label),
                new SqlDataPreprocessing("@notes",DataPreprocessing.notes),
                new SqlDataPreprocessing("@processing_time",DataPreprocessing.processing_time),
                new SqlDataPreprocessing("@tokenized_text",DataPreprocessing.tokenized_text),
                new SqlDataPreprocessing("@format",DataPreprocessing.format),
                new SqlDataPreprocessing("@data_id",DataPreprocessing.data_id),
                new SqlDataPreprocessing("@cleaned_text",DataPreprocessing.cleaned_text),
                new SqlDataPreprocessing("@validation_result",DataPreprocessing.validation_result),
                new SqlDataPreprocessing("@status",DataPreprocessing.status),
                new SqlDataPreprocessing("@raw_text",DataPreprocessing.raw_text),
                new SqlDataPreprocessing("@source",DataPreprocessing.source),
            };
            return DatabaseHelper.ExecuteNonQuery(DataPreprocessingSql, DataPreprocessingParames) > 0;
        }
    }
}