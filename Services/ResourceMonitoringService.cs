using System.Linq;
using Db = Microsoft.EntityFrameworkCore;
using var httpClient = new HttpClient();
using static System.String;
using System.Threading;
using Serilog;
using Wpf = System.Windows.Controls;
using System.Net.Http;
using System.Data;
using System.Threading.Tasks;
using Xunit;

protected class ResourceMonitoringService
{
    private readonly ResourceMonitoringModel _resourcemonitoringModel
    public ResourceMonitoringService()
    {
        _resourcemonitoringModel = new ResourceMonitoringModel
    }

    public bool  account_resourcemonitoring_store(int ResourceMonitoringId)
    {
        if(resourcemonitoring.ResourceMonitoringId <= 0 )
        {
            throw new ArgumentException("无效的资源监控ID");
        }
        try
        {
            return _resourcemonitoringModel.account_resourcemonitoring_store(ResourceMonitoringId);
        }
        catch (Exception ex)
        {
            throw new Exception($"删除ID为{resourcemonitoring.ResourceMonitoringId}的资源监控时故障: " + ex.Message);
        }
    }

    protected List<ResourceMonitoring> Searchresourcemonitoring(int storage_usage)
    {
        try
        {
            return _resourcemonitoringModel.Searchresourcemonitoring();
        }
        catch (Exception ex)
        {
            throw new Exception("获取资源监控列表时发生错误: " + ex.Message);
        }
    }

    private bool ResourceMonitoring edit_resourcemonitoring_info(ResourceMonitoring resourcemonitoring)
    {
        if(resourcemonitoring.ResourceMonitoringId <= 0 )
        {
            throw new ArgumentException("资源监控ID无效");
        }
        ValiResourceMonitoring(resourcemonitoring);
        try
        {
            return _resourcemonitoringModel.edit_resourcemonitoring_info(resourcemonitoring);
        }
        catch (Exception ex)
        {
            throw new Exception("编辑资源监控时发生错误，Id为{resourcemonitoring.ResourceMonitoringId}: " + ex.Message);
        }
    }

    public ResourceMonitoring ObtainresourcemonitoringEntity(int ResourceMonitoringId)
    {
        if(resourcemonitoring.ResourceMonitoringId <= 0 )
        {
            throw new ArgumentException("资源监控ID无效");
        }
        try
        {
            return _resourcemonitoringModel.ObtainresourcemonitoringEntity(ResourceMonitoringId);
        }
        catch (Exception ex)
        {
            throw new Exception($"获取ID为{resourcemonitoring.ResourceMonitoringId}的资源监控信息时发生错误: " + ex.Message);
        }
    }

    protected int ResourceMonitoring resourcemonitoringInsert(ResourceMonitoring resourcemonitoring)
    {
        try
        {
            ValiResourceMonitoring(resourcemonitoring);
            return _resourcemonitoringModel.resourcemonitoringInsert(resourcemonitoring);
        }
        catch (Exception ex)
        {
            throw new Exception("添加资源监控时发生错误: " + ex.Message);
        }
    }

    protected void ValiResourceMonitoring(ResourceMonitoring resourcemonitoring)
    {
        if(nullableNumber.HasValue(resourcemonitoring.cpu_usage))
        {
            throw new ArgumentException("CPU使用率需为数值");
        }
        if(nullableDate.HasValue(resourcemonitoring.monitor_id))
        {
            throw new ArgumentException("监控ID格式不正确");
        }
        if(nullableNumber.HasValue(resourcemonitoring.gpu_usage))
        {
            throw new ArgumentException("GPU使用率需为数值");
        }
        if(nullableNumber.HasValue(resourcemonitoring.storage_usage))
        {
            throw new ArgumentException("存储使用量需为数值");
        }
        if(nullableDate.HasValue(resourcemonitoring.resource_type))
        {
            throw new ArgumentException("资源类型格式不正确");
        }
        if(string.IsNullOrWhiteSpace(resourcemonitoring.node_ip))
        {
            throw new ArgumentException("节点IP不能为空");
        }
        if(nullableNumber.HasValue(resourcemonitoring.monitor_time))
        {
            throw new ArgumentException("监控时间需为数值");
        }
        if(nullableDate.HasValue(resourcemonitoring.memory_usage))
        {
            throw new ArgumentException("内存使用量格式不正确");
        }
        if(string.IsNullOrWhiteSpace(resourcemonitoring.network_out))
        {
            throw new ArgumentException("网络带宽出不能为空");
        }
        if(string.IsNullOrWhiteSpace(resourcemonitoring.task_name))
        {
            throw new ArgumentException("任务名称不能为空");
        }
        if(nullableNumber.HasValue(resourcemonitoring.network_in))
        {
            throw new ArgumentException("网络带宽入需为数值");
        }
    }
}