<template>
    <div class="sidebar p-0">
        <div class="navbar m-0 top-row navbar-dark">
            <div class="navbar-brand d-flex justify-content-between align-items-center m-0 px-4">                
                <span>SIDEBAR</span>
                <button class="navbar-toggler" type="button" aria-controls="offcanvasNavbar" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>
        </div>

        <div class="sidebar-content">
            <ul class="nav flex-column">
                <li class="nav-item px-3">                    
                    <a class="nav-link" href="#" >
                        <i class="bi bi-house-door-fill px-2"></i>
                        Home
                    </a>
                </li>
                
                <li class="nav-item dropdown px-3">                    
                    <a class="nav-link dropdown-toggle" href="#"  role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        <i class="bi bi-bar-chart-fill px-2"></i>
                        Fetch data
                    </a>

                    <ul class="dropdown-menu bg-dark">
                        <li><a class="dropdown-item" href="#">Action</a></li>
                        <li><a class="dropdown-item" href="#">Another action</a></li>
                        <li><hr class="dropdown-divider"></li>
                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                    </ul>
                </li>

                <li class="nav-item px-3">
                    <a class="nav-link" href="#">
                        <i class="bi bi-person-check-fill px-2"></i>
                        Counter
                    </a>
                </li>
            </ul>                
        </div>

        <footer class="fixed-bottom">
            <a class="nav-link" href=""><i class="bi bi-gear-fill px-2"></i>Config</a>
        </footer>
    </div>
</template>

<script>
export default {
  name: 'SideBar'
}
</script>

<style scoped>
    .sidebar {    
        background-color: rgb(52, 58, 64);
    }

    span {
        color: rgba(250, 250, 250, 0.98);
    }

    .sidebar-content {        
        display: flex;
        flex-direction: column;
    }

    .sidebar-footer {
        position: fixed;
        bottom: 0;
    }

    footer {
        color: rgba(250,250,250,0.98);
        font-size: 0.98rem;
        padding-left: 20px;
        padding-top: 10px;        
        padding-bottom: 20px;        

        color: #d7d7d7;
        height: 3rem;
    }



    .navbar-brand {
        width: 100%;
        height: 100%;
    }

    .navbar-toggler {
        border: 0;
    }

    

    .oi {
        width: 2rem;
        font-size: 1.1rem;
        vertical-align: text-top;
        top: -2px;
    }

    .top-row {
        height: 3.5rem;
        background-color: rgb(31, 35, 38);
        padding: 5px;
    }

    .nav-item, .nav-item a {
        color: rgba(250,250,250,0.98);
        font-size: 0.98rem;
        padding-bottom: 0.5rem;
    }

    .nav-item:first-of-type {
        padding-top: 1rem;
    }

    .nav-item:last-of-type {
        padding-bottom: 1rem;
    }

    .nav-item a {
        color: #d7d7d7;
        border-radius: 4px;
        height: 3rem;
        display: flex;
        align-items: center;
        line-height: 3rem;
    }

    .nav-item a.active {
        background-color: rgba(255,255,255,0.25);
        color: white;
    }

    .nav-item a:hover {
        background-color: rgba(255,255,255,0.1);
        color: white;
    }

    

</style>