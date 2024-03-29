﻿using MusicApp.Common;
using MusicApp.PageView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MusicApp.Models
{
    public class MainWindowModel : NotifyBase
    {
        /// <summary>
        /// 最大化图标
        /// </summary>
        private string _zoomWindowButContent = "\xe65d";
        public string ZoomWindowButContent
        {
            get
            { return this._zoomWindowButContent; }
            set
            {
                _zoomWindowButContent = value;
                DoNotify();
            }
        }

        /// <summary>
        /// 当前页面
        /// </summary>
        private FrameworkElement _page;
        public FrameworkElement Page
        {
            get
            { return this._page; }
            set
            {
                _page = value;
                DoNotify();
            }
        }

        /// <summary>
        /// 侧边菜单选中状态
        /// </summary>
        private MenusChecked _menusChecked;
        public MenusChecked MenusChecked
        {
            get
            { return this._menusChecked; }
            set
            {
                _menusChecked = value;
                switch (_menusChecked)
                {
                    case MenusChecked.FoundMusicPage:
                        Page = PageManager.foundMusicPage;
                        break;
                    case MenusChecked.PodcastPage:
                        Page = PageManager.podcastPage;
                        break;
                    case MenusChecked.VideoPage:
                        Page = PageManager.videoPage;
                        break;
                    case MenusChecked.FocusOnPage:
                        Page = PageManager.focusOnPage;
                        break;
                    case MenusChecked.FMPage:
                        Page = PageManager.fMPage;
                        break;
                    case MenusChecked.LikeMusicPage:
                        Page = PageManager.likeMusicPage;
                        break;
                    case MenusChecked.LocalAndDownloadPage:
                        Page = PageManager.localAndDownloadPage;
                        break;
                    case MenusChecked.RecentPlayPage:
                        Page = PageManager.recentPlayPage;
                        break;
                    case MenusChecked.SongListOfDayPage://每日推荐歌曲列表
                        Page = PageManager.SongListOfDayPage;
                        break;
                }
                DoNotify();
            }
        }

        /// <summary>
        /// 带参数跳转
        /// </summary>
        /// <param name="menusChecked"></param>
        /// <param name="param"></param>
        public void SetMenusChecked(MenusChecked menusChecked,object param)
        {
            switch (menusChecked)
            {
                case MenusChecked.SongListDetailsPage://歌单
                    Page = PageManager.SongListDetailsPage((string)param);
                    break;
            }
            DoNotify("MenusChecked");
        }


        /// <summary>
        /// 主页面标题
        /// </summary>
        private string _titleName = "";
        public string TitleName
        {
            get
            { return this._titleName; }
            set
            {
                _titleName = value;
                DoNotify();
            }
        }

        /// <summary>
        /// 播放停止按钮图片
        /// </summary>
        private string _playButImage;
        public string PlayButImage
        {
            get
            {
                if (_playButImage == null) _playButImage = "/Assets/Images/TaskbarItemInfo/stop.png";   //初始为stop

                return this._playButImage; }
            set
            {
                _playButImage = value;
                DoNotify();
            }
        }

        /// <summary>
        /// 任务栏缩略图
        /// </summary>
        private ImageSource _overlayImage;
        public ImageSource OverlayImage
        {
            get
            { return this._overlayImage; }
            set
            {
                _overlayImage = value;
                DoNotify();
            }
        }


    }


    //添加新的page

    public enum MenusChecked
    {
        FoundMusicPage,
        PodcastPage,
        VideoPage,
        FocusOnPage,
        LivePage,
        FMPage,
        LikeMusicPage,
        LocalAndDownloadPage,
        RecentPlayPage,
        SongListOfDayPage,
        SongListDetailsPage
    }
}
