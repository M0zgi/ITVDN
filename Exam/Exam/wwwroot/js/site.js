let products = new Vue({
    el: "#products",
    data: {
        products: [],
        url: "/Home/Products"
    },
    created() {
        this.Loaded();
    },
    methods: {
        Loaded() {
            axios.get(this.url)
                .then((response) => {
                    /*console.log(response.data);*/
                    this.products = response.data;
                    
            })
        }
    }
})

//let productsnew = new Vue({
//    el: "#productsnew",
//    data: {
//        productsnew: [],
//        url: "/Home/Products"
//    },
//    created() {
//        this.Loaded();
//    },
//    methods: {
//        Loaded() {
//            axios.get(this.url)
//                .then((response) => {
//                    //console.log(response.data);
//                    this.productsnew = response.data;

//                })
//        }
//    }
//})