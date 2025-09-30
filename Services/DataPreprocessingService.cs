using System.Reflection;
using Project = MyCompany.Project;
using Microsoft.Extensions.Logging;
using Db = Microsoft.EntityFrameworkCore;
using Xunit;
using static System.Math;
using Newtonsoft.Json;
using System.Globalization;
using System.Windows.Forms;

 class DataPreprocessingService
{
    private readonly DataPreprocessingModel _datapreprocessingModel
    public DataPreprocessingService()
    {
        _datapreprocessingModel = new DataPreprocessingModel
    }

    public int DataPreprocessing datapreprocessingInsert(DataPreprocessing datapreprocessing)
    {
        try
        {
            ValiDataPreprocessing(datapreprocessing);
            return _datapreprocessingModel.datapreprocessingInsert(datapreprocessing);
        }
        catch (Exception ex)
        {
            throw new Exception("添加数据预处理时发生错误: " + ex.Message);
        }
    }

    public void ValiDataPreprocessing(DataPreprocessing datapreprocessing)
    {
        if(string.IsNullOrWhiteSpace(datapreprocessing.label))
        {
            throw new ArgumentException("标注标签不能为空");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.notes))
        {
            throw new ArgumentException("备注不能为空");
        }
        if(nullableDate.HasValue(datapreprocessing.processing_time))
        {
            throw new ArgumentException("预处理时间格式不正确");
        }
        if(nullableNumber.HasValue(datapreprocessing.tokenized_text))
        {
            throw new ArgumentException("分词结果需为数值");
        }
        if(nullableDate.HasValue(datapreprocessing.format))
        {
            throw new ArgumentException("数据格式格式不正确");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.data_id))
        {
            throw new ArgumentException("数据ID不能为空");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.cleaned_text))
        {
            throw new ArgumentException("清洗后文本不能为空");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.validation_result))
        {
            throw new ArgumentException("校验结果不能为空");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.status))
        {
            throw new ArgumentException("处理状态不能为空");
        }
        if(string.IsNullOrWhiteSpace(datapreprocessing.raw_text))
        {
            throw new ArgumentException("原始文本不能为空");
        }
        if(nullableNumber.HasValue(datapreprocessing.source))
        {
            throw new ArgumentException("数据来源需为数值");
        }
    }

    protected bool DataPreprocessing edit_datapreprocessing_info(DataPreprocessing datapreprocessing)
    {
        if(datapreprocessing.DataPreprocessingId <= 0 )
        {
            throw new ArgumentException("数据预处理ID无效");
        }
        ValiDataPreprocessing(datapreprocessing);
        try
        {
            return _datapreprocessingModel.edit_datapreprocessing_info(datapreprocessing);
        }
        catch (Exception ex)
        {
            throw new Exception("编辑数据预处理时发生错误，Id为{datapreprocessing.DataPreprocessingId}: " + ex.Message);
        }
    }

    private List<DataPreprocessing> Searchdatapreprocessing(bigint label)
    {
        try
        {
            return _datapreprocessingModel.Searchdatapreprocessing();
        }
        catch (Exception ex)
        {
            throw new Exception("获取数据预处理列表时发生错误: " + ex.Message);
        }
    }

    protected bool  account_datapreprocessing_store(int DataPreprocessingId)
    {
        if(datapreprocessing.DataPreprocessingId <= 0 )
        {
            throw new ArgumentException("无效的数据预处理ID");
        }
        try
        {
            return _datapreprocessingModel.account_datapreprocessing_store(DataPreprocessingId);
        }
        catch (Exception ex)
        {
            throw new Exception($"删除ID为{datapreprocessing.DataPreprocessingId}的数据预处理时故障: " + ex.Message);
        }
    }

    public DataPreprocessing ObtaindatapreprocessingEntity(int DataPreprocessingId)
    {
        if(datapreprocessing.DataPreprocessingId <= 0 )
        {
            throw new ArgumentException("数据预处理ID无效");
        }
        try
        {
            return _datapreprocessingModel.ObtaindatapreprocessingEntity(DataPreprocessingId);
        }
        catch (Exception ex)
        {
            throw new Exception($"获取ID为{datapreprocessing.DataPreprocessingId}的数据预处理信息时发生错误: " + ex.Message);
        }
    }
}