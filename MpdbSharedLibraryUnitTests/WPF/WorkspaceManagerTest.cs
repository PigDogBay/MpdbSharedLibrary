
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.Collections;
using System;
using System.Collections.ObjectModel;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    public class MockWorkSpace : IDisposable
    {
        public bool Disposed { get; set; }
        public int ID { get; set; }
        public MockWorkSpace(int id)
        {
            ID = id;
            Disposed = false;
        }
        public void Dispose() { Disposed = true; }
    }

    /// <summary>
    ///This is a test class for WorkspaceManagerTest and is intended
    ///to contain all WorkspaceManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WorkspaceManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for WorkspaceManager Constructor
        ///</summary>
        [TestMethod()]
        public void WorkspaceManagerConstructorTest()
        {
            WorkspaceManager target = new WorkspaceManager();
            Assert.AreEqual(0, target.Workspaces.Count);
        }

        /// <summary>
        ///A test for CloseAllWorkspaces
        ///</summary>
        [TestMethod()]
        public void CloseAllWorkspacesTest()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            MockWorkSpace mws3 = new MockWorkSpace(3);
            target.Workspaces.Add(mws1);
            target.Workspaces.Add(mws2);
            target.Workspaces.Add(mws3);
            target.CloseAllWorkspaces();
            Assert.AreEqual(0, target.Workspaces.Count);
            Assert.IsTrue(mws1.Disposed);
            Assert.IsTrue(mws2.Disposed);
            Assert.IsTrue(mws3.Disposed);
        }

        /// <summary>
        ///A test for CloseOtherWorkspaces
        ///</summary>
        [TestMethod()]
        public void CloseOtherWorkspacesTest()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            MockWorkSpace mws3 = new MockWorkSpace(3);
            target.Workspaces.Add(mws1);
            target.Workspaces.Add(mws2);
            target.Workspaces.Add(mws3);
            target.SetActiveWorkspace(mws2);
            target.CloseOtherWorkspaces();
            Assert.AreEqual(1, target.Workspaces.Count);
            Assert.IsTrue(mws1.Disposed);
            Assert.IsFalse(mws2.Disposed);
            Assert.IsTrue(mws3.Disposed);
        }

        /// <summary>
        ///A test for CloseWorkspace
        ///</summary>
        [TestMethod()]
        public void CloseWorkspaceTest1()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            MockWorkSpace mws3 = new MockWorkSpace(3);
            target.Workspaces.Add(mws1);
            target.Workspaces.Add(mws2);
            target.Workspaces.Add(mws3);
            target.SetActiveWorkspace(mws2);
            target.CloseWorkspace();
            Assert.AreEqual(2, target.Workspaces.Count);
            Assert.IsFalse(mws1.Disposed);
            Assert.IsTrue(mws2.Disposed);
            Assert.IsFalse(mws3.Disposed);
        }
        /// <summary>
        ///A test for CloseWorkspace, no workspaces to close
        ///</summary>
        [TestMethod()]
        public void CloseWorkspaceTest2()
        {
            WorkspaceManager target = new WorkspaceManager();
            target.CloseWorkspace();
        }

        /// <summary>
        ///A test for GetCurrentWorkspace and SetActiveWorkspace
        ///</summary>
        [TestMethod()]
        public void GetCurrentWorkspaceTest()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            MockWorkSpace mws3 = new MockWorkSpace(3);
            target.Workspaces.Add(mws1);
            target.Workspaces.Add(mws2);
            target.Workspaces.Add(mws3);
            target.SetActiveWorkspace(mws2);
            var actual = target.GetCurrentWorkspace();
            Assert.AreEqual(mws2, actual);
        }

        /// <summary>
        ///A test for Show
        ///</summary>
        [TestMethod()]
        public void ShowTest1()
        {
            WorkspaceManager target = new WorkspaceManager();
            target.Show(() => { return new MockWorkSpace(42); }, typeof(MockWorkSpace));
            Assert.AreEqual(1, target.Workspaces.Count);
        }
        /// <summary>
        ///A test for Show, test that type can be only added once
        ///</summary>
        [TestMethod()]
        public void ShowTest2()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            target.Show(() => { return mws1; }, typeof(MockWorkSpace));
            target.Show(() => { return mws2; }, typeof(MockWorkSpace));
            Assert.AreEqual(1, target.Workspaces.Count);
        }
        /// <summary>
        ///A test for Show, this version of show allows multiple workspaces of the same type
        ///</summary>
        [TestMethod()]
        public void ShowTest3()
        {
            WorkspaceManager target = new WorkspaceManager();
            MockWorkSpace mws1 = new MockWorkSpace(1);
            MockWorkSpace mws2 = new MockWorkSpace(2);
            target.Workspaces.Add(mws1);
            target.Show(mws2);
            Assert.AreEqual(2, target.Workspaces.Count);
            Assert.AreEqual(mws2, target.GetCurrentWorkspace());
        }
    }
}
