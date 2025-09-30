using System.Reflection;
using static System.Math;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;
using System.Windows;
using System.Threading;
using System.Globalization;
 partial class ResourceMonitoringUi : Form
{
    protectedResourceMonitoringService _resourcemonitoringService;
    List<ResourceMonitoring> _resourcemonitoring
    pulic ResourceMonitoringForm()
    {
        InitializeComponent();
        _resourcemonitoringService = new ResourceMonitoringService
        LoadResourceMonitoring();
    }

    protected static void Searchresourcemonitoring()
    {
        Console.WriteLine("| CPU使用率 | 监控ID | GPU使用率 | 存储使用量 | 资源类型 | 节点IP | 监控时间 | 内存使用量 | 网络带宽出 | 任务名称 | 网络带宽入 | ");
        try
        {
            var resourcemonitorings = _resourcemonitoringService.Searchresourcemonitoring();
            foreach (var resourcemonitoring in resourcemonitorings)
            {
                Console.WriteLine($"| {resourcemonitoring.cpu_usage ,2} | {resourcemonitoring.monitor_id?.ToString("yyyy-MM-dd") ?? "N/A" ,16} | {resourcemonitoring.gpu_usage?.ToString("yyyy-MM-dd") ?? "N/A" ,-6} | {resourcemonitoring.storage_usage?.ToString("yyyy-MM-dd") ?? "N/A" ,4} | {resourcemonitoring.resource_type ,6} | {resourcemonitoring.node_ip?.ToString("yyyy-MM-dd") ?? "N/A" ,22} | {resourcemonitoring.monitor_time?.ToString("yyyy-MM-dd") ?? "N/A" ,-12} | {resourcemonitoring.memory_usage?.ToString("yyyy-MM-dd") ?? "N/A" ,2} | {resourcemonitoring.network_out?.ToString("yyyy-MM-dd") ?? "N/A" ,-16} | {resourcemonitoring.task_name?.ToString("yyyy-MM-dd") ?? "N/A" ,-14} | {resourcemonitoring.network_in ,-2} |");
                Console.WriteLine($"共 {resourcemonitorings.Count} 个资源监控");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"资源监控搜索错误: {ex.Message}");
        }
    }

    private static void edit_resourcemonitoring_info()
    {
        if (!int.TryParse(Console.ReadLine(), out int resourcemonitoringId))
        {
            Console.WriteLine("无效的资源监控ID");
            return;
        }
            Console.WriteLine($当前"CPU使用率:{ resourcemonitoring.cpu_usage?.ToString("N") ?? "N/A"}");
            Console.Write("新CPU使用率:");
            var newcpu_usage = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newcpu_usage))
            {
                if (int.TryParse(newcpu_usage, out var cpu_usage))
                {
                    resourcemonitoring.cpu_usage = cpu_usage;
                }
                else
                {
                    resourcemonitoring.cpu_usage = null;
                }
            }
            Console.WriteLine($当前"监控ID:{ resourcemonitoring.monitor_id?.ToString("N") ?? "N/A"}");
            Console.Write("新监控ID:");
            var newmonitor_id = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newmonitor_id))
            {
                if (int.TryParse(newmonitor_id, out var monitor_id))
                {
                    resourcemonitoring.monitor_id = monitor_id;
                }
                else
                {
                    resourcemonitoring.monitor_id = null;
                }
            }
            Console.WriteLine($当前"GPU使用率:{ resourcemonitoring.gpu_usage}");
            Console.Write("新GPU使用率:");
            var newgpu_usage = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                resourcemonitoring.gpu_usage = newgpu_usage;
            }
            Console.WriteLine($当前"存储使用量:{ resourcemonitoring.storage_usage}");
            Console.Write("新存储使用量:");
            var newstorage_usage = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                resourcemonitoring.storage_usage = newstorage_usage;
            }
            Console.WriteLine($当前"资源类型:{ resourcemonitoring.resource_type?.ToString("C") ?? "N/A"}");
            Console.Write("新资源类型:");
            var newresource_type = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newresource_type))
            {
                if (decimal.TryParse(newresource_type, out var resource_type))
                {
                    resourcemonitoring.resource_type = resource_type;
                }
                else
                {
                    resourcemonitoring.resource_type = null;
                }
            }
            Console.WriteLine($当前"节点IP:{ resourcemonitoring.node_ip}");
            Console.Write("新节点IP:");
            var newnode_ip = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                resourcemonitoring.node_ip = newnode_ip;
            }
            Console.WriteLine($当前"监控时间:{ resourcemonitoring.monitor_time?.ToString("N") ?? "N/A"}");
            Console.Write("新监控时间:");
            var newmonitor_time = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newmonitor_time))
            {
                if (int.TryParse(newmonitor_time, out var monitor_time))
                {
                    resourcemonitoring.monitor_time = monitor_time;
                }
                else
                {
                    resourcemonitoring.monitor_time = null;
                }
            }
            Console.WriteLine($当前"内存使用量:{ resourcemonitoring.memory_usage}");
            Console.Write("新内存使用量:");
            var newmemory_usage = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                resourcemonitoring.memory_usage = newmemory_usage;
            }
            Console.WriteLine($当前"网络带宽出:{ resourcemonitoring.network_out?.ToString("yyyy-MM-dd") ?? "N/A"}");
            Console.Write("新网络带宽出:");
            var newnetwork_out = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newnetwork_out))
            {
                if (DateTime.TryParse(newnetwork_out, out var network_out))
                {
                    resourcemonitoring.network_out = network_out;
                }
                else
                {
                    resourcemonitoring.network_out = null;
                }
            }
            Console.WriteLine($当前"任务名称:{ resourcemonitoring.task_name?.ToString("yyyy-MM-dd") ?? "N/A"}");
            Console.Write("新任务名称:");
            var newtask_name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newtask_name))
            {
                if (DateTime.TryParse(newtask_name, out var task_name))
                {
                    resourcemonitoring.task_name = task_name;
                }
                else
                {
                    resourcemonitoring.task_name = null;
                }
            }
            Console.WriteLine($当前"网络带宽入:{ resourcemonitoring.network_in}");
            Console.Write("新网络带宽入:");
            var newnetwork_in = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newName))
            {
                resourcemonitoring.network_in = newnetwork_in;
            }

        var isActiveInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(isActiveInput))
        {
            resourcemonitoring.IsActive = isActiveInput.ToUpper() == "Y";
        }
        bool ResourceMonitoringsuccess = _resourcemonitoringService.edit_resourcemonitoring_info(resourcemonitoring);
        if(ResourceMonitoringsuccess)
        {
            Console.WriteLine("资源监控更新成功");
        }
        eles
        {
            Console.WriteLine("更新资源监控失败");
        }
    }

    private static void resourcemonitoringInsert()
    {
        try
        {
            varresourcemonitoring = newResourceMonitoring();
            Console.Write("CPU使用率: ");
            resourcemonitoring.cpu_usage = Console.ReadLine();
            Console.Write("监控ID: ");
            resourcemonitoring.monitor_id = Console.ReadLine();
            Console.Write("GPU使用率: ");
            if(int.TryParse(Console.ReadLine(), out var gpu_usage))
            {
                resourcemonitoring.gpu_usage = gpu_usage
            }
            Console.Write("存储使用量: ");
            if(DateTime.TryParse(Console.ReadLine(), out var storage_usage))
            {
                resourcemonitoring.storage_usage = storage_usage
            }
            Console.Write("资源类型: ");
            if(DateTime.TryParse(Console.ReadLine(), out var resource_type))
            {
                resourcemonitoring.resource_type = resource_type
            }
            Console.Write("节点IP: ");
            resourcemonitoring.node_ip = Console.ReadLine();
            Console.Write("监控时间: ");
            if(decimal.TryParse(Console.ReadLine(), out var monitor_time))
            {
                resourcemonitoring.monitor_time = monitor_time
            }
            Console.Write("内存使用量: ");
            if(decimal.TryParse(Console.ReadLine(), out var memory_usage))
            {
                resourcemonitoring.memory_usage = memory_usage
            }
            Console.Write("网络带宽出: ");
            if(int.TryParse(Console.ReadLine(), out var network_out))
            {
                resourcemonitoring.network_out = network_out
            }
            Console.Write("任务名称: ");
            resourcemonitoring.task_name = Console.ReadLine();
            Console.Write("网络带宽入: ");
            if(DateTime.TryParse(Console.ReadLine(), out var network_in))
            {
                resourcemonitoring.network_in = network_in
            }

            var isActiveInput = Console.ReadLine();
            resourcemonitoring.IsActive = string.IsNullOrWhiteSpace(isActiveInput) || isActiveInput.ToUpper() == "Y";

            int resourcemonitoringId = _resourcemonitoring.ServiceresourcemonitoringInsert(resourcemonitoring);
            Console.WriteLine($"资源监控添加成功，ID: {resourcemonitoringId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"错误的资源监控: {ex.Message}");
        }
    }

    private static void account_resourcemonitoring_store()
    {
        if (!int.TryParse(Console.ReadLine(), out int resourcemonitoringId))
        {
            Console.WriteLine("无效的资源监控ID");
            return;
        }
        try
        {
            Console.Write($"确认删除ID为{resourcemonitoringId}的项目吗?(Y/N): ");
            var confirm = Console.ReadLine();
            if (confirm?.ToUpper() != "Y")
            {
                Console.WriteLine("操作已取消");
                return;
            }
            bool ResourceMonitoringsuccess = _resourcemonitoringService.account_resourcemonitoring_store(resourcemonitoringId);
            if(ResourceMonitoringsuccess)
            {
                Console.WriteLine("资源监控删除成功");
            }
            else
            {
                Console.WriteLine("删除资源监控失败，可能资源监控不存在");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"资源监控错误: {ex.Message}");
        }
    }
}