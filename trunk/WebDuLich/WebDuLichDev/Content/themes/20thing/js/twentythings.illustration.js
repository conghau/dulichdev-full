/**
 * Sub-namespace.
 * @type {Object}
 */
TT.illustrations = {};


/**
 * The frame rate at which the illustration animations will be rendered.
 * @type {number}
 */
TT.illustrations.FRAME_RATE = 30;


/**
 * The location of all our illustration asset images.
 * @type {string}
 */
TT.illustrations.ASSETS_URL = '/Content/themes/20Things/css/images/';


/**
 * The single interval that runs to render the animations.
 * @type {number}
 */
TT.illustrations.interval = -1;


/**
 * Updates the component by checking if there is any animation available for
 * the current page, if there is it will be activated otherwise all animations
 * will be deactivated.
 * @param {String} currentPage Current page.
 */
TT.illustrations.update = function(currentPage) {
  TT.illustrations.deactivate();

  if (currentPage && !TT.navigation.isHomePage() &&
      !TT.navigation.isFullScreen()) {

    TT.log('Activate animation: ' + currentPage.attr('class'));
    if (currentPage.hasClass('title-threed') &&
        currentPage.hasClass('page-1')) {
      TT.illustrations.threed.activate($('div.image1', currentPage));
    }

  }
};


/**
 * Deactivates rendering of all illustration animations.
 */
TT.illustrations.deactivate = function() {
  clearInterval(TT.illustrations.interval);
};


/**
 * Creates a new canvas element with the specified properties.
 * @param {Object} parent Parent node.
 * @param {Object} world World stage.
 * @return {Object} Canvas element.
 */
TT.illustrations.createCanvas = function(parent, world) {
  var canvas = $('<canvas></canvas>');

  canvas[0].width = world.width;
  canvas[0].height = world.height;

  parent.append(canvas);

  TT.illustrations.updateCanvasPosition(parent, world);

  return canvas;
};


/**
 * Creates a new canvas element with the specified properties.
 * @param {Object} parent Parent node.
 * @param {Object} world World stage.
 * @return {boolean} If image width or height is equal to 0.
 */
TT.illustrations.updateCanvasPosition = function(parent, world) {
  var canvas = $('canvas', parent);

  canvas.css({
    position: 'absolute',
    left: $('img', parent).position().left + world.x,
    top: $('img', parent).position().top + world.y
  });

  return $('img', parent).width() !== 0 || $('img', parent).height() !== 0;
};


/**
 * 3D illustration.
 * @type {Object}
 */
TT.illustrations.threed = {

  // DOM & API elements.
  canvas: null,
  context: null,
  container: null,
  image: null,
  cloudImage: null,
  clouds: [],
  alpha: 0,

  // Defines the dimensions and position of the world which this animation is
  // drawn in.
  world: { x: 0, y: 0, width: 320, height: 150 },

  // Flags if the position for the canvas has been set.
  positioned: false,


  /**
   * Initialize.
   * @param {Object} container Container node.
   * @this {Object} Illustration class.
   */
  initialize: function(container) {

    // Only initialize once.
    if (this.canvas === null) {

      // Store references to the container and image we are animating.
      this.container = container;
      this.image = $('img', container);

      this.canvas = TT.illustrations.createCanvas(container, this.world);
      this.context = this.canvas[0].getContext('2d');

      this.cloudImage = new Image();
      this.cloudImage.src = TT.illustrations.ASSETS_URL + '3d01_clouds.png';

      this.clouds.push({
        source: { x: 0, y: 0, width: 63, height: 35 },
        x: 44,
        y: 16,
        originalX: 44,
        originalY: 16,
        velocity: { x: 0, y: 0 }
      });

      this.clouds.push({
        source: { x: 0, y: 36, width: 70, height: 40 },
        x: 147,
        y: 10,
        originalX: 147,
        originalY: 10,
        velocity: { x: 0, y: 0 }
      });

      this.clouds.push({
        source: { x: 0, y: 78, width: 84, height: 50 },
        x: 213,
        y: 48,
        originalX: 212,
        originalY: 48,
        velocity: { x: 0, y: 0 }
      });

    }
    else {
      this.positioned = TT.illustrations.updateCanvasPosition(this.container,
          this.world);
    }
  },


  /**
   * Activates rendering for this animation.
   * @param {Object} container Container node.
   * @this {Object} Illustration class.
   */
  activate: function(container) {
    this.initialize(container);

    TT.illustrations.interval =
        setInterval(this.render, 1000 / TT.illustrations.FRAME_RATE);
  },


  /**
   * Handler for the interval used to draw the animation.
   */
  render: function() {
    TT.illustrations.threed.draw();
  },


  /**
   * Draws the current state of this animation.
   * @this {Object} Illustration class.
   */
  draw: function() {
    if (!this.positioned) {
      this.positioned =
          TT.illustrations.updateCanvasPosition(this.container, this.world);
    }

    this.context.clearRect(0, 0, this.world.width, this.world.height);

    if (this.cloudImage.complete) {

      this.alpha = Math.min(this.alpha + 0.1, 1);
      this.context.globalAlpha = this.alpha;

      // Go through and update/draw each cloud.
      for (var i = 0; i < this.clouds.length; i++) {

        var cloud = this.clouds[i];

        cloud.x += cloud.velocity.x;
        cloud.y += cloud.velocity.y;

        cloud.velocity.x *= 0.96;
        cloud.velocity.y *= 0.96;

        var speed = 0.3;

        if (Math.abs(cloud.velocity.x) < 0.01) {
          if (cloud.x > cloud.originalX) {
            cloud.velocity.x -= 0.05 + Math.random() * speed;
          }
          else {
            cloud.velocity.x += 0.05 + Math.random() * speed;
          }
        }

        if (Math.abs(cloud.velocity.y) < 0.01) {
          if (cloud.y > cloud.originalY) {
            cloud.velocity.y -= 0.01 + Math.random() * speed;
          }
          else {
            cloud.velocity.y += 0.01 + Math.random() * speed;
          }
        }

        this.context.save();

        this.context.translate(cloud.x, cloud.y);
        this.context.drawImage(this.cloudImage, cloud.source.x, cloud.source.y,
            cloud.source.width, cloud.source.height, 0, 0, cloud.source.width,
            cloud.source.height);

        this.context.restore();

      }
    }
  }
};


///**
// * HTML/CSS "Make Up" illustration.
// * @type {Object}
// */
TT.illustrations.html = {

  // DOM & API elements.
  canvas: null,
  context: null,
  container: null,
  image: null,

  // Defines the dimensions and position of the world which this animation is
  // drawn in.
  world: { x: 100, y: -15, width: 150, height: 200 },

  bulbs: [
    { x: 27, y: 22, strength: 0, momentum: 0, size: 10 },
    { x: 62, y: 30, strength: 0, momentum: 0, size: 10 },
    { x: 90, y: 39, strength: 0, momentum: 0, size: 10 },
    { x: 117, y: 48, strength: 0, momentum: 0, size: 10 },
    { x: 22, y: 59, strength: 0, momentum: 0, size: 10 },
    { x: 23, y: 89, strength: 0, momentum: 0, size: 10 },
    { x: 24, y: 115, strength: 0, momentum: 0, size: 10 },
    { x: 25, y: 139, strength: 0, momentum: 0, size: 10 },
    { x: 124, y: 87, strength: 0, momentum: 0, size: 10 },
    { x: 124, y: 116, strength: 0, momentum: 0, size: 10 },
    { x: 124, y: 144, strength: 0, momentum: 0, size: 10 },
    { x: 124, y: 178, strength: 0, momentum: 0, size: 10 }
  ],


  /**
   * Initialize illustration.
   * @param {Object} container Container node.
   * @this {Object} Illustration class.
   */
  initialize: function(container) {

    // Only initialize once.
    if (this.canvas === null) {

      // Store references to the container and image we are animating.
      this.container = container;
      this.image = $('img', container);

      this.canvas = TT.illustrations.createCanvas(container, this.world);
      this.context = this.canvas[0].getContext('2d');
    }
    else {
      TT.illustrations.updateCanvasPosition(this.container, this.world);
    }
  },


  /**
   * Activates rendering for this animation.
   * @param {Object} container Container node.
   * @this {Object} Illustration class.
   */
  activate: function(container) {
    this.initialize(container);

    TT.illustrations.interval =
        setInterval(this.render, 1000 / TT.illustrations.FRAME_RATE);
  },


  /**
   * Handler for the interval used to draw the animation.
   */
  render: function() {
    TT.illustrations.html.draw();
  },
};