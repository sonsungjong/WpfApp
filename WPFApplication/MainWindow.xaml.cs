﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// net7 WPF Application

/*
 <<WPF Application 선택하기>>

결론적으로, 새로운 WPF 프로젝트를 시작할 때 "WPF Application"을 선택하는 것이 좋습니다. 
이를 통해 최신 기능, 성능 개선 및 지원을 활용할 수 있습니다. 
하지만 기존 프로젝트와 호환성이 중요한 경우, "WPF App (.NET Framework)"를 선택할 수 있습니다. 
*/

namespace WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}